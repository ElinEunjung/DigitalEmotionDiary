using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models.Configuration
{
	public class ImageConfiguration : IEntityTypeConfiguration<Image>
	{
		public void Configure(EntityTypeBuilder<Image> builder)
		{
			builder.HasKey(i => i.Id);

			builder.HasOne(i => i.DiaryEntry)
				   .WithOne(de => de.Image)
				   .HasForeignKey<Image>(i => i.DiaryEntryId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasData(
			   new Image
			   {
				   Id = 1,
				   Path = "./Resources/Images/hankang.webp", // TODO: Consider Absolute Path or Environment variable!
				   UploadedAt = DateTime.UtcNow,
				   Description = "writer Han Kang",
				   DiaryEntryId = 1,
			   },
			   new Image
			   {
				   Id = 2,
				   Path = "./Resources/Images/120324.png",
				   UploadedAt = DateTime.UtcNow,
				   Description = "the night under martial law",
				   DiaryEntryId = 2,
			   },
			   new Image
			   {
				   Id = 3,
				   Path = "./Resources/Images/maja.jpeg",
				   UploadedAt = DateTime.UtcNow,
				   Description = "maja",
				   DiaryEntryId = 3,
			   }
			 );
		}
	}
}
