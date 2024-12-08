using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models.Configuration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder) 
		{
			builder.HasKey(u => u.Id);

			builder.HasMany(u => u.DiaryEntries)
				   .WithOne(u => u.User)
				   .HasForeignKey(d => d.UserId) // DiaryEntry should have UserId as a foreign key
				   .OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(u => u.Comments)
				   .WithOne(c => c.User)
				   .HasForeignKey(c => c.UserId)
				   .OnDelete(DeleteBehavior.Restrict);


			builder.HasMany(u => u.Likes)
				   .WithOne(l => l.User)
				   .HasForeignKey(l => l.UserId)
				   .OnDelete(DeleteBehavior.Restrict);

			
			builder.HasData(
			   new User
			   {
				   Id = 1,
				   UserName = "Elin",
				   Email = "elin@gmail.com",
				   Password = "pass1",
				   ProfileImagePath = "elinProfile.png",
			   },
			   new User
			   {
				   Id = 2,
				   UserName = "Ivan",
				   Email = "ivan@gmail.com",
				   Password = "pass2",
				   ProfileImagePath = "ivanProfile.png",
			   }
			 );
		}
	}
}
