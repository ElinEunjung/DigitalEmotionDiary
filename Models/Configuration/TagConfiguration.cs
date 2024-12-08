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
	public class TagConfiguration : IEntityTypeConfiguration<Tag>
	{
		public void Configure(EntityTypeBuilder<Tag> builder)
		{
			builder.HasKey(t => t.Id);


			builder.HasMany(t => t.EntryTags)
				   .WithOne(et => et.Tag)
			       .HasForeignKey(et => et.TagId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasData(
				new Tag
				{
					Id = 1,
					Name = "news",
				},
				new Tag
				{
					Id = 2,
					Name = "shocking",
				}
			);
		}
	}
}
