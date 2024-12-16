using DigitalEmotionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.DTO
{
	public class CommentDTO
	{
		public long Id { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; }
		public long UserId { get; set; }
		public long DiaryEntryId { get; set; }

		// Related User Information 
		public string UserName { get; set; }
	}
}
