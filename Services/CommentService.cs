using DigitalEmotionDiary.Data;
using DigitalEmotionDiary.Data.Repositories;
using DigitalEmotionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Services
{
	public class CommentService
	{
		private readonly CommentRepository _commentRepository;
	


		public CommentService(
			CommentRepository commentRepository
			)
		{
			_commentRepository = commentRepository
		}
		public void CreateComment(long diaryEntryId, long userId, string content)
		{
			var comment = new Comment
			{
				DiaryEntryId = diaryEntryId,
				UserId = userId,
				Content = content,
				CreatedAt = DateTime.Now,
			};

			_commentRepository.CreateComment(comment);
			_commentRepository.Save();
		}

		public void UpdateComment(Comment comment)
		{
			_commentRepository.UpdateComment(comment);
			_commentRepository.Save();
		}

		public void DeleteCommentById(long commentId)
		{
			_commentRepository.DeleteCommentById(commentId);
			_commentRepository.Save();
		}

		public List<Comment> GetCommentsByDiaryEntry(int diaryEntryId)
		{
			return _commentRepository.GetCommentsByDiaryEntry(diaryEntryId);
		}
	}
}

