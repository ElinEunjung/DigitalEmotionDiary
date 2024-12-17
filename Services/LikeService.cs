using DigitalEmotionDiary.Data;
using DigitalEmotionDiary.Data.Repositories;
using DigitalEmotionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Services
{
	public class LikeService
	{
		private readonly LikeRepository _likeRepository;

		public LikeService(
			LikeRepository likeRepository
			)
		{
			_likeRepository = likeRepository;
		}


		public void LikeEntry(long diaryEntryId, long userId)
		{
			if(_likeRepository.Exists(diaryEntryId, userId))
			{
				throw new InvalidOperationException("A like for this diary entry by the user already exists.");
			}

			var like = new Like 
			{ 
				DiaryEntryId = diaryEntryId,
				UserId = userId 
			};

			_likeRepository.AddLikeToEntry(diaryEntryId, userId);
			_likeRepository.SaveChanges();
		}

		public void UnLikeEntry(long diaryEntryId, long userId)
		{
			_likeRepository.RemoveLikeFromEntry(diaryEntryId, userId);
			_likeRepository.SaveChanges();
		}

		public IEnumerable<Like> GetLikesByDiaryEntryId(long diaryEntryId)
		{
			return _likeRepository.GetLikesByDiaryEntryId(diaryEntryId);
		}

		public IEnumerable<Like> GetLikesByUserId(long userId)
		{
			return _likeRepository.GetLikesByUserId(userId);
		}

		public long CountLikesByDiaryEntryId(long diaryEntryId)
		{
			return _likeRepository.CountLikesByDiaryEntryId(diaryEntryId);
		}

		public bool Exists(long diaryEntryId, long userId)
		{
			return _likeRepository.Exists(diaryEntryId, userId);
		}
	}
}

