using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models.Configuration
{
	public class CommentConfiguration : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.HasKey(c => c.Id);

			builder.HasOne(c => c.DiaryEntry)
				   .WithMany(de => de.Comments)
				   .HasForeignKey(c => c.DiaryEntryId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(c => c.User)
					.WithMany(u => u.Comments)
					.HasForeignKey(c => c.UserId)
					.OnDelete(DeleteBehavior.Restrict);

			builder.HasData(
			   new Comment
			   {
				   Id = 1,
				   Content = "Congraturation! Woohoo!",
				   CreatedAt = DateTime.UtcNow,
				   DiaryEntryId = 1,
				   UserId = 2
			   },
			   new Comment
			   {
				   Id = 2,
				   Content = "We need to fight for democracy!",
				   CreatedAt = DateTime.UtcNow,
				   DiaryEntryId = 2,
				   UserId = 2
			   },
			   new Comment
			   {
				   Id = 3,
				   Content = "awwww so happy for you!",
				   CreatedAt = DateTime.UtcNow,
				   DiaryEntryId = 2,
				   UserId = 1
			   }
			);
		}
	}
}
