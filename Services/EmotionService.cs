using DigitalEmotionDiary.Data;
using DigitalEmotionDiary.Data.Repositories;
using DigitalEmotionDiary.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Services
{
	public class EmotionService
	{
		private readonly EmotionRepository _emotionRepository;
		private readonly EmotionTypeRepository _emotionTypeRepository;
		private readonly DigitalEmotionDiaryDbContext _dbContext;

		public EmotionService(
			EmotionRepository emotionRepository,
			EmotionTypeRepository emotionTypeRepository,
			DigitalEmotionDiaryDbContext dbContext
			)
		{
			_emotionRepository = emotionRepository;
			_emotionTypeRepository = emotionTypeRepository;
			_dbContext = dbContext;
		}

		public IEnumerable<Emotion> GetAllEmotions()
		{
			return _emotionRepository.GetAllEmotions();
		}

		public void UpdateEmotionBackgroundColor(int typeId, string newColor)
		{
			_emotionRepository.UpdateBackgroundColor(typeId, newColor);
			_emotionRepository.SaveChanges();
		}

		public void CreateEmotionType(EmotionType emotionType)
		{
			_emotionTypeRepository.CreateEmotion(emotionType);
			_emotionTypeRepository.SaveChanges();
		}


		public void DeleteEmotionType(int emotionTypeId)
		{
			_emotionTypeRepository.DeleteEmotionById(emotionTypeId);
			_emotionTypeRepository.SaveChanges();
		}
	}
}