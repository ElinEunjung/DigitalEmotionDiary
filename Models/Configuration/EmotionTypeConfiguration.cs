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
	public class EmotionTypeConfiguration : IEntityTypeConfiguration<EmotionType>
	{
		public void Configure(EntityTypeBuilder<EmotionType> builder)
		{
			builder.HasKey(et => et.Id);

			builder.HasOne(et => et.Emotion)
				   .WithOne(e => e.EmotionType)
				   .HasForeignKey<Emotion>(e => e.EmotionTypeId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasData(
				new EmotionType { Id = 1, Name = "Happy" },
				new EmotionType { Id = 2, Name = "Energized" },
				new EmotionType { Id = 3, Name = "Tired" },
				new EmotionType { Id = 4, Name = "Anxious" },
				new EmotionType { Id = 5, Name = "Stressed" },
				new EmotionType { Id = 6, Name = "Sad" },
				new EmotionType { Id = 7, Name = "Annoyed" },
				new EmotionType { Id = 8, Name = "Neutral" }
				);
		}
	}
	
}
