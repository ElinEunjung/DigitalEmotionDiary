using DigitalEmotionDiary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Data
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

            modelBuilder.Entity<EntryTag>()
                .HasKey(et => new { et.DiaryEntryId, et.TagId });

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

			modelBuilder.Entity<Emotion>()
		        .HasOne(e => e.EmotionType)
		        .WithMany(et => et.Emotions)
		        .HasForeignKey(e => e.EmotionTypeId);

			modelBuilder.Entity<EmotionType>().HasData(
                new EmotionType { Id = 1, Name = "Happy" },
                new EmotionType { Id = 2, Name = "Energized" },
                new EmotionType { Id = 3, Name = "Tired" },
                new EmotionType { Id = 4, Name = "Anxious" },
                new EmotionType { Id = 5, Name = "Stressed" },
                new EmotionType { Id = 6, Name = "Sad" },
                new EmotionType { Id = 7, Name = "Annoyed" },
                new EmotionType { Id = 8, Name = "Neutral" }
                );
             

			modelBuilder.Entity<Emotion>().HasData(
			   new Emotion { Id = 1, EmotionTypeId = 1, BackgroundColor = "Yellow" },
		       new Emotion { Id = 2, EmotionTypeId = 2, BackgroundColor = "Orange" },
		       new Emotion { Id = 3, EmotionTypeId = 3, BackgroundColor = "Beige" },
		       new Emotion { Id = 4, EmotionTypeId = 4, BackgroundColor = "Brown" },
		       new Emotion { Id = 5, EmotionTypeId = 5, BackgroundColor = "Light Red" },
		       new Emotion { Id = 6, EmotionTypeId = 6, BackgroundColor = "Grey/Black" },
		       new Emotion { Id = 7, EmotionTypeId = 7, BackgroundColor = "Red" },
		       new Emotion { Id = 8, EmotionTypeId = 8, BackgroundColor = "White" }
			    );

		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Resources/DigitalEmotionDiary.db");
        }


    }
}
