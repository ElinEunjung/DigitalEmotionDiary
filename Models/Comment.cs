using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class Comment
	{
		public long Id { get; set; }
		public required string Content { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		// Foreign key
		public long DiaryEntryId { get; set; }
		public long UserId { get; set; }


		// Navigation property
		public DiaryEntry? DiaryEntry { get; set; }
		public User? User { get; set; }
	}
}
