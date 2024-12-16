using DigitalEmotionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.DTO
{
	public class DiaryEntryDTO
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool IsPublic { get; set; }
		public long UserId { get; set; }
		public int EmotionId { get; set; }
		public long? ImageId { get; set; }


		// Related Entities Information for client-side usage
		public string UserName { get; set; }
		public string EmotionName { get; set; }

		// Option
		public int CommentCount { get; set; }
		public int LikeCount { get; set; }

	}
}
