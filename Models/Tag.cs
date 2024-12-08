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

		// Navigation property
		public ICollection<EntryTag> EntryTags { get; set; } = new List<EntryTag>(); // One to Many
	}
}
