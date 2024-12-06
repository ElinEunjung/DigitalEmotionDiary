using DigitalEmotionDiary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Entity <Emotion> has no key
			modelBuilder.Entity<Emotion>().HasNoKey();

			modelBuilder.Entity<EntryTag>()
				.HasKey(et => new {et.DiaryEntryId, et.TagId});

			// One to Many (DiaryEntry - EntryTag)
			modelBuilder.Entity<DiaryEntry>()
				.HasMany(d => d.EntryTags) 
				.WithOne(et => et.DiaryEntry) 
			    .HasForeignKey(e => e.DiaryEntryId); 

			// One to Many (Tag - EntryTag)
			modelBuilder.Entity<Tag>()
				.HasMany(t => t.EntryTags) 
				.WithOne(et => et.Tag) 
				.HasForeignKey(et => et.TagId); 


			
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source = Resources/DigitalEmotionDiary.db");
		}

		
	}
}
