using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models.Configuration
{
	public class LikeConfiguration : IEntityTypeConfiguration<Like>
	{
		public void Configure(EntityTypeBuilder<Like> builder)
		{
			builder.HasKey(l => l.Id);


			builder.HasOne(l => l.DiaryEntry)
				   .WithMany(de=> de.Likes)
				   .HasForeignKey(l => l.DiaryEntryId)
				   .OnDelete(DeleteBehavior.Cascade);


			builder.HasOne(l => l.User) 
					.WithMany(u => u.Likes)
					.HasForeignKey(l => l.UserId)
					.OnDelete(DeleteBehavior.Cascade);

			builder.HasData(
				new Like
				{
					Id = 1,
					DiaryEntryId = 1,
					UserId = 2
				},
				new Like
				{
					Id = 2,
					DiaryEntryId = 2,
					UserId = 2
				}
			);

		}
	}
}
