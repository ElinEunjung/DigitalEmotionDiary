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
				},
				new DiaryEntry
				{
					Id = 4,
					Title = "Kimchi day",
					Content = "Time to make kimchi for next year, I'm ready for the war!!",
					CreatedAt = DateTime.UtcNow,
					IsPublic = true,
					UserId = 1,
					EmotionId = 1,
				},
				new DiaryEntry
				{
					Id = 5,
					Title = "Trip to Jeju",
					Content = "It's our family's yearly trip. Getting exceited!",
					CreatedAt = DateTime.UtcNow,
					IsPublic = true,
					UserId = 1,
					EmotionId = 1,
				},
				new DiaryEntry
				{
					Id = 6,
					Title = "Sickness",
					Content = "It's awful to get sick while I'm traveling.",
					CreatedAt = DateTime.UtcNow,
					IsPublic = false,
					UserId = 2,
					EmotionId = 7,
				},
				new DiaryEntry
				{
					Id = 7,
					Title = "Party",
					Content = "We live only once in our life. Let's party today! yay!",
					CreatedAt = DateTime.UtcNow,
					IsPublic = true,
					UserId = 2,
					EmotionId = 2,
				},
				new DiaryEntry
				{
					Id = 8,
					Title = "Shopping",
					Content = "So exicted, I'm in the middle of shopping heaven!",
					CreatedAt = DateTime.UtcNow,
					IsPublic = true,
					UserId = 1,
					EmotionId = 2,
				},
				new DiaryEntry
				{
					Id = 9,
					Title = "Chirstmas",
					Content = "So exicted, I'm in the middle of shopping heaven!",
					CreatedAt = DateTime.UtcNow,
					IsPublic = true,
					UserId = 1,
					EmotionId = 2,
				},
				new DiaryEntry
				{
					Id = 10,
					Title = "Oyster",
					Content = "So exicted, I'm in the middle of shopping heaven!",
					CreatedAt = DateTime.UtcNow,
					IsPublic = true,
					UserId = 1,
					EmotionId = 2,
				},
				new DiaryEntry
				{
					Id = 11,
					Title = "Riga, my home",
					Content = "Food in Riga is best in my opinion!",
					CreatedAt = DateTime.UtcNow,
					IsPublic = true,
					UserId = 2,
					EmotionId = 2,
				},
				new DiaryEntry
				{
					Id = 12,
					Title = "Healthy life",
					Content = "work out everyday is so important. I don't want to get sick...",
					CreatedAt = DateTime.UtcNow,
					IsPublic = false,
					UserId = 2,
					EmotionId = 8,
				}
			);
		}
	}

}
