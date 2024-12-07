using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class DiaryEntry
	{
		 public long Id { get; set; }
		 public required string Title { get; set; }
		 public required string Content { get; set; }

		 public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		 public bool IsPublic { get; set; } = false;

		// Foreign key 
		public long UserId { get; set; } 
		public long EmotionId { get; set; }


		// Navigation Properties
		public User? User { get; set; }
		public Emotion? Emotion { get; set; }
		public ICollection<EntryTag>? EntryTags { get; set; } // Middle table for Many to many
		public ICollection<Comment>? Comments { get; set; } // One to Many
		public ICollection<Like>? Likes { get; set; } // One to Many
		public ICollection<Image>? Images { get; set; } // One to Many
	
	}

}
