using DigitalEmotionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Data.Repositories
{
	public class EmotionTypeRepository
	{
		private readonly DigitalEmotionDiaryDbContext _dbContext;

		public EmotionTypeRepository(DigitalEmotionDiaryDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<EmotionType> GetAllEmotions()
		{
			return _dbContext.EmotionType.ToList();
		}

		public void CreateEmotion(EmotionType emotionType)
		{
			_dbContext.EmotionType.Add(emotionType);
		}

		public void UpdateEmotion(EmotionType emotionType)
		{
			_dbContext.EmotionType.Update(emotionType);
		}

		public void DeleteEmotionById(int emotionTypeId)
		{
			var emotionType = _dbContext.EmotionType.Find(emotionTypeId);
			if (emotionType != null)
			{
				_dbContext.EmotionType.Remove(emotionType);
			}
		}

		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}
	}
}
