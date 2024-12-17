using DigitalEmotionDiary.Data.Repositories;
using DigitalEmotionDiary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Services
{
	public class ImageService
	{
		private readonly ImageRepository? _imageRepository;

		public ImageService(ImageRepository? imageRepository)
		{
			_imageRepository = imageRepository;
		}

		public void UploadEntryImage(long userId, long entryId, string filePath, string? description = null)
		{
			if (string.IsNullOrWhiteSpace(filePath))
				throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

			if (!System.IO.File.Exists(filePath))
				throw new FileNotFoundException("The specified file does not exist.", filePath);
			
			var image = new Image
			{
				Path = filePath,
				UploadedAt = DateTime.Now,
				Description = description,
				DiaryEntryId = entryId,
			};

			_imageRepository.UploadEntryImage(image);
			_imageRepository.SaveChanges();
		}

		public Image? GetImageById(long id)
		{
			return _imageRepository.GetImageById(id);
		}
		public List<Image> GetImagesByEntryId(long entryId)
		{
			return _imageRepository.GetImagesByEntryId(entryId);
		}

		public void DeleteImage(long id)
		{
			_imageRepository.DeleteImage(id);
			_imageRepository.SaveChanges();

		}
	}

	
}
