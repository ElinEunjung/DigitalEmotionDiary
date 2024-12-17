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

		public IEnumerable<DiaryEntry> GetDiaryEntriesByTag(long userId, string tagName)
		{
			return _dbContext.DiaryEntry
				.Where(entry => entry.UserId == userId &&
										entry.EntryTags.Any(et => et.Tag.Name == tagName))
				.Include(entry => entry.EntryTags)
					.ThenInclude(et =>  et.Tag)
				.ToList();
		}

		public void UpdateDiaryEntryVisibility(long id, bool isPublic)
		{
			var diaryEntry = _dbContext.DiaryEntry.Find(id);
			if (diaryEntry != null)
			{
				diaryEntry.IsPublic = isPublic;
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
			}
		}

		public void DeleteTagFromDiaryEntry(long entryId, Tag tag)
		{
			var entryTag = _dbContext.EntryTag
				.FirstOrDefault(et => et.DiaryEntryId == entryId && et.TagId == tag.Id);
			
			if (entryTag != null) 
			{
				_dbContext.EntryTag.Remove(entryTag);
			}
		}

		public void CreateDiaryEntry(DiaryEntry diaryEntry)
		{
			_dbContext.DiaryEntry.Add(diaryEntry);
		}

		public void UpdateDiaryEntry(DiaryEntry diaryEntry)
		{
			_dbContext.DiaryEntry.Update(diaryEntry);
		}

		public IEnumerable<DiaryEntry> GetAllDiaryEntry()
		{
			return _dbContext.DiaryEntry.ToList();
		}
		public void DeleteDiaryEntryByUserIdAndEntryId(long userId, long entryId)
		{
		
			var diaryEntry = _dbContext.DiaryEntry.FirstOrDefault(de => de.UserId == userId && de.Id == entryId );
			if (diaryEntry != null)
			{
				_dbContext.DiaryEntry.Remove(diaryEntry);
			}
		}

		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}
	}
}
