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
			   new Emotion { Id = 1, EmotionTypeId = 1, BackgroundColor = "#ffd700" },
			   new Emotion { Id = 2, EmotionTypeId = 2, BackgroundColor = "#ff7f50" },
			   new Emotion { Id = 3, EmotionTypeId = 3, BackgroundColor = "#c39797" },
			   new Emotion { Id = 4, EmotionTypeId = 4, BackgroundColor = "#794044" },
			   new Emotion { Id = 5, EmotionTypeId = 5, BackgroundColor = "#ff4040" },
			   new Emotion { Id = 6, EmotionTypeId = 6, BackgroundColor = "#808080" },
			   new Emotion { Id = 7, EmotionTypeId = 7, BackgroundColor = "#ff0000" },
			   new Emotion { Id = 8, EmotionTypeId = 8, BackgroundColor = "#eeeeee" }
				);

		}

	}
}
