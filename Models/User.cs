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
		public required string UserName { get; set; } 
		public required string Email { get; set; }
		public required string Password { get; set; } 
		public string? ProfileImagePath { get; set; }
		
		// Navigation property for related DiaryEntries
		public ICollection<DiaryEntry> DiaryEntries { get; set; } = new List<DiaryEntry>();  // One to Many
		public ICollection<Comment> Comments { get; set; } = new List<Comment>(); // One to Many
		public ICollection<Like> Likes { get; set; } = new List<Like>();
	}
	
}



