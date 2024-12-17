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
	public class EmotionConfiguration : IEntityTypeConfiguration<Emotion>
	{
		public void Configure(EntityTypeBuilder<Emotion> builder)
		{
			builder.HasKey(e => e.Id);

			builder.HasOne(e => e.EmotionType)
				   .WithOne(et => et.Emotion)
				   .HasForeignKey<Emotion>(e => e.EmotionTypeId)
				   .OnDelete(DeleteBehavior.Restrict);

			builder.HasData(
			   new Emotion { Id = 1, EmotionTypeId = 1, BackgroundColor = "Yellow" },
			   new Emotion { Id = 2, EmotionTypeId = 2, BackgroundColor = "Orange" },
			   new Emotion { Id = 3, EmotionTypeId = 3, BackgroundColor = "Beige" },
			   new Emotion { Id = 4, EmotionTypeId = 4, BackgroundColor = "Brown" },
			   new Emotion { Id = 5, EmotionTypeId = 5, BackgroundColor = "Red" },
			   new Emotion { Id = 6, EmotionTypeId = 6, BackgroundColor = "Grey" },
			   new Emotion { Id = 7, EmotionTypeId = 7, BackgroundColor = "Black" },
			   new Emotion { Id = 8, EmotionTypeId = 8, BackgroundColor = "White" }
				);

		}

	}
}
