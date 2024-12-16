using DigitalEmotionDiary.Data.Repositories;
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

		public DiaryEntryService(DiaryEntryRepository diaryEntryRepository)
		{
			_diaryEntryRepository = diaryEntryRepository;
		}

		public void CreateDiaryEntry(DiaryEntry diaryEntry)
		{
			_diaryEntryRepository.CreateDiaryEntry(diaryEntry);
			_diaryEntryRepository.SaveChanges();
		}

		public void UpdateDiaryEntry(DiaryEntry diaryEntry)
		{
			_diaryEntryRepository.UpdateDiaryEntry(diaryEntry);
			_diaryEntryRepository.SaveChanges();
		}

		public IEnumerable<DiaryEntry> GetAllDiaryEntries()
		{
			return _diaryEntryRepository.GetAllDiaryEntry();
		}

		public void DeleteDiaryEntryById(long diaryEntryId)
		{
			_diaryEntryRepository.DeleteDiaryEntryById(diaryEntryId);
			_diaryEntryRepository.SaveChanges();
		}

	}
}
