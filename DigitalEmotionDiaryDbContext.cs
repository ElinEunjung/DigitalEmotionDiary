using DigitalEmotionDiary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary
{
	public class DigitalEmotionDiaryDbContext : DbContext
	{
		public DbSet<DiaryEntry> DiaryEntry => Set<DiaryEntry>();
		public DbSet<User> User => Set<User>();
		public DbSet<Emotion> Emotion => Set<Emotion>();
		public DbSet<Like> Like => Set<Like>();
		public DbSet<Comment> Comment => Set<Comment>();
		public DbSet<Tag> Tag => Set<Tag>();
		public DbSet<EntryTag> EntryTag => Set<EntryTag>();
		public DbSet<Image> Image => Set<Image>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source = Resources/DigitalEmotionDiary.db");
		}
	}
}
