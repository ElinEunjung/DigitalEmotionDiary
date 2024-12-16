using DigitalEmotionDiary.Data.Repositories;
using DigitalEmotionDiary.DTO;
using DigitalEmotionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Services
{
	public class DiaryEntryService
	{
		private readonly DiaryEntryRepository _diaryEntryRepository;
		private readonly UserRepository _userRepository;

		public DiaryEntryService(
			DiaryEntryRepository diaryEntryRepository,
			UserRepository userRepository
			)
		{
			_diaryEntryRepository = diaryEntryRepository;
			_userRepository = userRepository;
		}

		public void PublishDiaryEntry(long userId, DiaryEntryDTO diaryEntry)
		{
			if (diaryEntry == null)
			{
				throw new ArgumentException(nameof(diaryEntry), "DiaryEntryDTO cannot be null.");
			}

			var user = _userRepository.GetUserById(userId);
			if (user == null)
			{
				throw new ArgumentException($"User with ID {userId} does not exist");
			}

			var entry = new DiaryEntry
			{
				UserId = userId,
				Title = diaryEntry.Title,
				Content = diaryEntry.Content,
				CreatedAt = diaryEntry.CreatedAt,
				IsPublic = true,
				EmotionId = diaryEntry.EmotionId,
				ImageId = diaryEntry.ImageId
			}; 
			

			_diaryEntryRepository.CreateDiaryEntry(entry);
			_diaryEntryRepository.SaveChanges();
		}

		public void UpdateDiaryEntry(long userId, long diaryEntryId, DiaryEntryDTO updateEntry)
		{
			var diaryEntry = _diaryEntryRepository.GetDiaryEntriesByUserId(userId)
									   .FirstOrDefault(de => de.Id == diaryEntryId);
			
			if (diaryEntry != null)
			{
				diaryEntry.Title = updateEntry.Title;
				diaryEntry.Content = updateEntry.Content;
				diaryEntry.EmotionId = updateEntry.EmotionId;

				_diaryEntryRepository.UpdateDiaryEntry(diaryEntry);
				_diaryEntryRepository.SaveChanges();
			}
		}

		public IEnumerable<DiaryEntry> GetAllDiaryEntries()
		{
			return _diaryEntryRepository.GetAllDiaryEntry();
		}

		public void DeleteDiaryEntryById(long userId, long diaryEntryId)
		{    
			_diaryEntryRepository.DeleteDiaryEntryById(diaryEntryId);
			_diaryEntryRepository.SaveChanges();
		}

		public IEnumerable<DiaryEntry> FilterDiaryEntriesByEmotion(long userId, int emotionId, DateTime? startDate, DateTime? endDate)
		{
			return _diaryEntryRepository.GetDiaryEntriesByEmotion(userId,emotionId, startDate, endDate);
			
		}

		public void SetDiaryEntryVisibility(long userId, long diaryEntryId, bool isPublic)
		{
			_diaryEntryRepository.UpdateDiaryEntryVisibility(diaryEntryId, isPublic);
			_diaryEntryRepository.SaveChanges();
		}

	}
}
