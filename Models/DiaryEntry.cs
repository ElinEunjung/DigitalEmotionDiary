using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class DiaryEntry
	{
		 public long Id { get; set; }
		 public required string Title { get; set; }
		 public required string Content { get; set; }

		 public required Emotion Mood { get; set; }
		 public DateTime CreatedAt { get; set; } = DateTime.Now;
		 public bool IsPublic { get; set; } = false;

		// Foreign key 
		public long UserId { get; set; } 


		// Navigation Properties
		public User? User { get; set; } 
		public ICollection<EntryTag>? EntryTags { get; set; } // Middle table for Many to many
		public ICollection<Comment>? Comments { get; set; } // One to Many
		public ICollection<Like>? Likes { get; set; } // One to Many
	
	}

	
}
