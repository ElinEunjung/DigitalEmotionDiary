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
	public class DiaryEntryConfiguration : IEntityTypeConfiguration<DiaryEntry>
	{
		public void Configure(EntityTypeBuilder<DiaryEntry> builder)
		{
			builder.HasKey(d => d.Id);

			builder.HasOne(d => d.User)
				   .WithMany(u => u.DiaryEntries)
				   .HasForeignKey(d => d.UserId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(d => d.Emotion)
				   .WithMany(e => e.DiaryEntries)
				   .HasForeignKey(d => d.EmotionId)
				   .OnDelete(DeleteBehavior.Restrict);
					

			builder.HasMany(d => d.EntryTags)
				   .WithOne(et => et.DiaryEntry)
				   .HasForeignKey(et => et.DiaryEntryId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(d => d.Comments)
				   .WithOne(c => c.DiaryEntry)
					.HasForeignKey(c => c.DiaryEntryId)
				   .OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(d => d.Likes)
				   .WithOne(l => l.DiaryEntry)
				   .HasForeignKey(l => l.DiaryEntryId)
				   .OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(d => d.Image)
				   .WithOne(i => i.DiaryEntry)
				   .HasForeignKey<Image>(i => i.DiaryEntryId)
				   .OnDelete(DeleteBehavior.Restrict);


			builder.HasData(
				new DiaryEntry
				{
					Id = 1,
					Title = "Good news",
					Content = "Han Kang, South korean writer won the Nobel Prize in Literature! I'm so proud of her",
					CreatedAt = DateTime.UtcNow,
					IsPublic = true,
					ImageId = 1,
					UserId = 1,
					EmotionId = 1,
				},
				new DiaryEntry
				{
					Id = 2,
					Title = "A complete shock",
					Content = "An idiot declared martial law today, luckly paliament overruled it in two hours, could save our democracy at the end. What a drama! ",
					CreatedAt = DateTime.UtcNow,
					IsPublic = true,
					ImageId = 2,
					UserId = 1,
					EmotionId = 4,
				},
				new DiaryEntry
				{
					Id = 3,
					Title = "Maya",
					Content = "I adapted new cat, she's so adorable!",
					CreatedAt = DateTime.UtcNow,
					IsPublic = true,
					ImageId = 3,
					UserId = 2,
					EmotionId = 2,
				}
			);
		}
	}

}
