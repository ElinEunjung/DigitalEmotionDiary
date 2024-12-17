using DigitalEmotionDiary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Data.Repositories
{
	public class CommentRepository
	{
		private readonly DigitalEmotionDiaryDbContext _dbContext;
		

		public CommentRepository(DigitalEmotionDiaryDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public void AddComment(Comment comment)
		{
			_dbContext.Comment.Add(comment);			
		}

		public void UpdateComment(Comment comment)
		{
			_dbContext.Comment.Update(comment);
			
		}
		
		public void DeleteCommentByUserIdAndCommentId(long userId, long commentId)
		{
			var comment = _dbContext.Comment.FirstOrDefault(c => c.Id == commentId && c.UserId == userId);
			if (comment != null)
			{
				_dbContext.Comment.Remove(comment);
			}
		}

		public List<Comment> GetCommentsByDiaryEntrId(int diaryEntryId)
		{
			return _dbContext.Comment
				.Where(c => c.DiaryEntryId == diaryEntryId)
				.ToList();
		}

		public void SaveChanges()
		{ 
			_dbContext.SaveChanges(); 
		}
	}
}