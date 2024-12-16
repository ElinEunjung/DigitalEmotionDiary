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

		public IEnumerable<DiaryEntry> GetDiaryEntriesByUserId(long userId)
		{
			return _dbContext.DiaryEntry
				.Where(de => de.UserId == userId).ToList();
		}

		public IEnumerable<DiaryEntry> GetDiaryEntriesByEmotion(long userId, int emotionId, DateTime? startDate , DateTime? endDate) 
		{
			var query = _dbContext.DiaryEntry.Where(de => de.UserId == userId && de.EmotionId == emotionId);
			
			if (startDate.HasValue)
				query = query.Where(de => de.CreatedAt >= startDate.Value);

			if (endDate.HasValue)
				query = query.Where(de => de.CreatedAt <= endDate.Value);

			return query.ToList();

		}

		public IEnumerable<DiaryEntry> GetDiaryEntriesByTag(Tag tag)
		{
			return (IEnumerable<DiaryEntry>)_dbContext.EntryTag
				.Where(entryTag => entryTag.TagId == tag.Id)
				.Select(EntryTag => EntryTag.DiaryEntryId)
				.ToList();
		}

		public void updateDiaryEntryVisibility(long id, bool isPublic)
		{
			var diaryEntry = _dbContext.DiaryEntry.Find(id);
			if (diaryEntry != null)
			{
				diaryEntry.IsPublic = isPublic;
				_dbContext.SaveChanges();
			}
		}

		public void AddTagToDiaryEntry(long entryId, Tag tag)
		{
			var diaryEntry = _dbContext.DiaryEntry.Find(entryId);
			if (diaryEntry != null)
			{
				var entryTag = new EntryTag
				{
					DiaryEntryId = entryId,
					TagId = tag.Id
				};

				_dbContext.EntryTag.Add(entryTag);
				_dbContext.SaveChanges();
			}
		}

		public void DeleteTagFromDiaryEntry(long entryId, Tag tag)
		{
			var entryTag = _dbContext.EntryTag
				.FirstOrDefault(et => et.DiaryEntryId == entryId && et.TagId == tag.Id);
			
			if (entryTag != null) 
			{
				_dbContext.EntryTag.Remove(entryTag);
				_dbContext.SaveChanges();
			}
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
