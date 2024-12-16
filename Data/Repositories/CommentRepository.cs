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
		public void CreateComment(Comment comment)
		{
			_dbContext.Comment.Add(comment);
			
		}

		public void UpdateComment(Comment comment)
		{
			_dbContext.Comment.Update(comment);
			
		}

		public void DeleteCommentById(long commentId)
		{
			var comment = _dbContext.Comment.Find(commentId);
			if (comment != null)
			{
				_dbContext.Comment.Remove(comment);
			}
		}

		public List<Comment> GetCommentsByDiaryEntry(int diaryEntryId)
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