using DigitalEmotionDiary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Data.Repositories
{
	public class EmotionRepository
	{
		private readonly DigitalEmotionDiaryDbContext _dbContext;

		public EmotionRepository(DigitalEmotionDiaryDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<Emotion> GetAllEmotions()
		{
			return _dbContext.Emotion
				.Include(e=> e.EmotionType)
				.ToList();
				
		}

		public Emotion? GetBackgroundColorByEmotionTypeId(int typeId)
		{
			return _dbContext.Emotion
				.FirstOrDefault(e => e.EmotionTypeId == typeId);
		}

		public void UpdateBackgroundColor(int typeId, string newBackgroundColor)
		{
			var emotion = _dbContext.Emotion
				.FirstOrDefault(e => e.EmotionTypeId == typeId);
			if (emotion != null)
			{
				emotion.BackgroundColor = newBackgroundColor;
				_dbContext.Emotion.Update(emotion);
			}
		}

		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}
	}
}
