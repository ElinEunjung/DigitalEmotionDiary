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
	public class EntryTagConfiguration : IEntityTypeConfiguration<EntryTag>
	{
		public void Configure(EntityTypeBuilder<EntryTag> builder)
		{
			builder.HasKey(et => new { et.DiaryEntryId, et.TagId });

			builder.HasData(
					new EntryTag
					{
						DiaryEntryId = 1,
						TagId = 1,
					},
					new EntryTag
					{
						DiaryEntryId = 2,
						TagId = 2,
					},
					new EntryTag
					{
						DiaryEntryId = 3,
						TagId = 1,
					}
			);
		}
	}
}
