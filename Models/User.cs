using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Models
{
	public class User
	{
		public long Id {  get; set; }
		public required string UserName { get; set; } = string.Empty;
		public required string Email { get; set; }
		public required string Password { get; set; } 
		public string? ProfileImagePath { get; set; }
		
		// Navigation property for related DiaryEntries
		public ICollection<DiaryEntry> DiaryEntries { get; set; } = [];  // One to Many
		public ICollection<Comment>? Comments { get; set; } = []; // One to Many
	}

	
}


