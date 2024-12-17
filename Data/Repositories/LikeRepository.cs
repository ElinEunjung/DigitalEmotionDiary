using DigitalEmotionDiary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Data.Repositories
{
	public class LikeRepository
	{
		private readonly DigitalEmotionDiaryDbContext _dbContext;


		public LikeRepository(DigitalEmotionDiaryDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void AddLikeToEntry(long entryId, long userId)
		{
			var existinglike = GetLike(entryId, userId);
			if (existinglike == null)
			{
				var like = new Like
				{
					DiaryEntryId = entryId,
					UserId = userId
				};

				_dbContext.Like.Add(like);
			}
		}

		public void RemoveLikeFromEntry(long entryId, long userId)
		{
			var like = GetLike(entryId, userId);
			_dbContext.Like.Remove(like);
		}

		public Like? GetLike(long diaryEntryId, long userId)
		{
			return _dbContext.Like.FirstOrDefault(l => l.DiaryEntryId == diaryEntryId && l.UserId == userId);
		}

		public IEnumerable<Like> GetLikesByDiaryEntryId(long diaryEntryId)
		{
			return _dbContext.Like.Where(l => l.DiaryEntryId == diaryEntryId).ToList();
		}

		public IEnumerable<Like> GetLikesByUserId(long userId)
		{
			return _dbContext.Like.Where(l => l.UserId == userId).ToList();
		}

		public long CountLikesByDiaryEntryId(long diaryEntryId)
		{
			return _dbContext.Like.Count(l => l.DiaryEntryId == diaryEntryId);
		}

		public bool Exists(long diaryEntryId, long userId)
		{
			return _dbContext.Like.Any(l => l.DiaryEntryId == diaryEntryId && l.UserId == userId);
		}

		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}

	}

}
