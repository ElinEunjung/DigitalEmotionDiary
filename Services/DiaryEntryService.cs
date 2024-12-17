using DigitalEmotionDiary.Data.Repositories;
using DigitalEmotionDiary.DTO;
using DigitalEmotionDiary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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

		

		public void PublishDiaryEntry(long userId, DiaryEntryDTO dto)
		{
			if (dto == null)
			{
				throw new ArgumentException("DiaryEntryDTO cannot be null.", nameof(dto));
			}

			var entry = new DiaryEntry
			{
				UserId = userId,
				Title = dto.Title,
				Content = dto.Content,
				CreatedAt = DateTime.Now,
				IsPublic = dto.IsPublic,
				EmotionId = dto.EmotionId,
				ImageId = dto.ImageId
			}; 
			

			_diaryEntryRepository.CreateDiaryEntry(entry);
			_diaryEntryRepository.SaveChanges();
		}

		public void UpdateDiaryEntry(long userId, long diaryEntryId, DiaryEntryDTO updateEntry)
		{
			var diaryEntry = _diaryEntryRepository
								.GetDiaryEntriesByUserId(userId)
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


		public DiaryEntry GetDiaryEntry(long userId, long diaryEntryId)
		{
			return _diaryEntryRepository
				.GetUserDiaryEntryByEntryId(userId, diaryEntryId)
				.FirstOrDefault();
		}

		public List<DiaryEntry> GetAllDiaryEntriesAccessibleToUser(long userId)
		{
			IEnumerable<DiaryEntry> ownEntries = _diaryEntryRepository.GetDiaryEntriesByUserId(userId);
			IEnumerable<DiaryEntry> nonOwnerPublicEntries =  _diaryEntryRepository.GetDiaryEntriesNonOwnedOpenEntries(userId);
			return ownEntries
			.Concat(nonOwnerPublicEntries)
			.ToList();
		}

		public List<DiaryEntry> GetEntryByColor(long userId, string backgroundColor)
		{
			IEnumerable<DiaryEntry> entriesBySpecificColor = _diaryEntryRepository.GetDiaryEntriesByBackgroundColor(userId, backgroundColor);
			return entriesBySpecificColor.ToList();
		}

		public void DeleteDiaryEntryByUserIdAndEntryId(long userId, long diaryEntryId)
		{    
			_diaryEntryRepository.DeleteDiaryEntryByUserIdAndEntryId(userId, diaryEntryId);
			_diaryEntryRepository.SaveChanges();
		}

		public List<DiaryEntry> FilterDiaryEntriesByEmotion(long userId, int emotionId, DateTime? startDate, DateTime? endDate)
		{
			return _diaryEntryRepository
			.GetDiaryEntriesByEmotion(userId,emotionId, startDate, endDate)
			.ToList();
			
		}

		public List<DiaryEntry> FilterDiaryEntriesByTag(long userId, string tagName)
		{
			if (string.IsNullOrEmpty(tagName))
				throw new ArgumentNullException(nameof(tagName), "Tag name cannot be null or empty.");

			var entries = _diaryEntryRepository.GetDiaryEntriesByTag(userId, tagName).ToList();

			return entries;
		}

		public List<DiaryEntry> FilterDiaryEntriesByBackgroundColor(long userId, string backgroundColor)
		{
			var entriesByBackgroundColor = _diaryEntryRepository.GetDiaryEntriesByBackgroundColor(userId, backgroundColor);
			return entriesByBackgroundColor.ToList();
		}

		public void SetDiaryEntryVisibility(long userId, long diaryEntryId, bool isPublic)
		{
			_diaryEntryRepository.UpdateDiaryEntryVisibility(diaryEntryId, isPublic);
			_diaryEntryRepository.SaveChanges();
		}

	}
}
