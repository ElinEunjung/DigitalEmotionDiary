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
		public int EmotionId { get; set; }

		// Optional Foreign Key
		public long? ImageId { get; set; } = null;


		// Navigation Properties
		public User User { get; set; }
		public Emotion Emotion { get; set; }
		public Image Image { get; set; }
		public ICollection<EntryTag> EntryTags { get; set; } = new List<EntryTag>(); // Middle table for Many to many
		public ICollection<Comment> Comments { get; set; } = new List<Comment>();// One to Many
		public ICollection<Like> Likes { get; set; } = new List<Like>();
	

	}

}
