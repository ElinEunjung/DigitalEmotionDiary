
using DigitalEmotionDiary.Models;

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

		public static DiaryEntryDTO FromDiaryEntry(DiaryEntry diaryEntry)
		{
			DiaryEntryDTO entryDTO = new DiaryEntryDTO();
			entryDTO.Id = diaryEntry.Id;
			entryDTO.Title = diaryEntry.Title;
			entryDTO.Content = diaryEntry.Content;
			entryDTO.CreatedAt = diaryEntry.CreatedAt;
			entryDTO.IsPublic = diaryEntry.IsPublic;
			entryDTO.UserId = diaryEntry.UserId;
			entryDTO.EmotionId = diaryEntry.EmotionId;
			entryDTO.ImageId = diaryEntry.ImageId;
			return entryDTO;
		}
	}
}
