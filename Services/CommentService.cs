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
			_commentRepository = commentRepository;
		}
		public void PostComment(long diaryEntryId, long userId, string content)
		{
			var comment = new Comment
			{
				Content = content,
				CreatedAt = DateTime.Now,
				DiaryEntryId = diaryEntryId,
				UserId = userId			
			};

			_commentRepository.AddComment(comment);
			_commentRepository.SaveChanges();
		}

		public void UpdateComment(Comment comment)
		{
			_commentRepository.UpdateComment(comment);
			_commentRepository.SaveChanges();
		}

		public void DeleteComment(long userId, long commentId)
		{
			_commentRepository.DeleteCommentByUserIdAndCommentId(userId, commentId);
			_commentRepository.SaveChanges();

		}

		public List<Comment> GetCommentsByDiaryEntryId(int diaryEntryId)
		{
			return _commentRepository.GetCommentsByDiaryEntrId(diaryEntryId);
		}
	}
}

