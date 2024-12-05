using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class Like
{
		public long Id { get; set; }

		// Foreign key
		public long DiaryEntryId { get; set; }
		public long UserId { get; set; }

		// Navigation property
		public DiaryEntry? DiaryEntry { get; set; } 
		public User? User { get; set; } 
	}
}
