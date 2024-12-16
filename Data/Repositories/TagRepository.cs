using DigitalEmotionDiary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Data.Repositories
{
	public class TagRepository
	{
		private readonly DigitalEmotionDiaryDbContext _dbContext;

		public TagRepository(DigitalEmotionDiaryDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void CreateTag(Tag tag)
		{
				if (tag == null)
				{
					throw new ArgumentNullException(nameof(tag), "Tag cannot be null.");
				}

				_dbContext.Tag.Add(tag);
		}

		public void UpdateTag(Tag tag)
		{
			_dbContext.Tag.Update(tag);
		}

		public void DeleteTag(Tag tag)
		{
			_dbContext.Tag.Remove(tag);
		}

		public List<EntryTag> GetTagsByDiaryEntryId(long diaryEntryId)
		{
			return _dbContext.EntryTag.Where(et => et.DiaryEntryId == diaryEntryId)
				.ToList();
		}

		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}

	}
}
