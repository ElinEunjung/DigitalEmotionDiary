using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class Image
	{
		public long Id { get; set; }
		public required string Path { get; set; } = string.Empty;
		public DateTime UploadeAt { get; set; } = DateTime.Now;
		public string? Description { get; set; }

		// Foreign key
		public long DiaryEntryId { get; set; }

		// Navigation Property
		public DiaryEntry? DiaryEntry { get; set; }
	}
}
