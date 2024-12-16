using DigitalEmotionDiary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Data.Repositories
{
	public class ImageRepository
	{
		private readonly DigitalEmotionDiaryDbContext _dbContext;

		public ImageRepository(DigitalEmotionDiaryDbContext dbContext)
		{
			_dbContext = dbContext;
			
		}

		public Image? GetImageById(long id)
		{
			return _dbContext.Image
				.Include(img => img.DiaryEntry) // load image with DiaryEntry
				.FirstOrDefault(img => img.Id == id);
		}

		public List<Image> GetImagesByEntryId(long entryId)
		{
			return _dbContext.Image
				.Where(img => img.DiaryEntryId == entryId)
				.ToList();
		}

		public void UploadEntryImage(Image image)
		{
			_dbContext.Image.Add(image);
			_dbContext.SaveChanges();
		}

		public void DeleteImage(long id)
		{
			var image = _dbContext.Image.FirstOrDefault(img => img.Id == id);
			_dbContext.Image.Remove(image);
			_dbContext.SaveChanges();
		}

		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}
	}
}
