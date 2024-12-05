using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class Tag
	{
		public long Id { get; set; }
		public required string Name { get; set; }
		public string? Color { get; set; }

		// Navigation property
		public ICollection<EntryTag>? EntryTags { get; set; } // One to Many
	}
}
