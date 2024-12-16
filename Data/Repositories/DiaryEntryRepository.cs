using DigitalEmotionDiary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Data.Repositories
{
	public class DiaryEntryRepository
	{
		private readonly DigitalEmotionDiaryDbContext _dbContext;
		
		public DiaryEntryRepository(DigitalEmotionDiaryDbContext dbContext)
		{
			_dbContext = dbContext;
		}


		public void CreateDiaryEntry(DiaryEntry diaryEntry)
		{
			_dbContext.DiaryEntry.Add(diaryEntry);
			_dbContext.SaveChanges();
		}

		public void UpdateDiaryEntry(DiaryEntry diaryEntry)
		{
			_dbContext.DiaryEntry.Update(diaryEntry);
			_dbContext.SaveChanges();
		}

		public IEnumerable<DiaryEntry> GetAllDiaryEntry()
		{
			return _dbContext.DiaryEntry.ToList();
		}
		public void DeleteDiaryEntryById(long diaryEntryId)
		{
			var diaryEntry = _dbContext.DiaryEntry.Find(diaryEntryId);
			if (diaryEntry != null)
			{
				_dbContext.DiaryEntry.Remove(diaryEntry);
				_dbContext.SaveChanges();
			}
		}

		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}
	}
}
