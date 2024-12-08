using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class EntryTag
	{
		public long Id { get; set; }
		public long DiaryEntryId { get; set; }  
		public long TagId { get; set; }

		// Navigation Property
		public DiaryEntry? DiaryEntry { get; set; } // One to many
		public Tag? Tag { get; set; } // One to many
	}
}

