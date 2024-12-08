using DigitalEmotionDiary.Models;
using DigitalEmotionDiary.Models.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Data
{
    public class DigitalEmotionDiaryDbContext : DbContext
    {
        public DbSet<DiaryEntry> DiaryEntry => Set<DiaryEntry>();
        public DbSet<User> User => Set<User>();
        public DbSet<Emotion> Emotion => Set<Emotion>();
        public DbSet<EmotionType> EmotionType => Set<EmotionType>();
        public DbSet<Like> Like => Set<Like>();
        public DbSet<Comment> Comment => Set<Comment>();
        public DbSet<Tag> Tag => Set<Tag>();
        public DbSet<EntryTag> EntryTag => Set<EntryTag>();
        public DbSet<Image> Image => Set<Image>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DiaryEntryConfiguration());
            modelBuilder.ApplyConfiguration(new EmotionConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new EmotionTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new EntryTagConfiguration());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Resources/DigitalEmotionDiary.db");
        }


    }
}
