using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class Emotion
	{
		public int Id { get; set; }
		public int EmotionTypeId { get; set; }
		public required string BackgroundColor { get; set; }


		// Navigation property
		public EmotionType? EmotionType { get; set; } = null;

		public ICollection<DiaryEntry> DiaryEntries { get; set; } = [];

	}
}