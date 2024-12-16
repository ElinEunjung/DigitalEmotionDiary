using DigitalEmotionDiary.Data.Repositories;
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
			
		}

		public void DeleteImage(long id)
		{
			_imageRepository.DeleteImage(id);
			_imageRepository.SaveChanges();

		}
	}

	
}
