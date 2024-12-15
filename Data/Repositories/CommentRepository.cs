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
		private readonly DiaryEntryRepository _diaryEntryRepository;

		public CommentRepository(
			DigitalEmotionDiaryDbContext dbContext,
			DiaryEntryRepository diaryEntryRepository
			)
		{
			_dbContext = dbContext;
			_diaryEntryRepository = diaryEntryRepository;
		}
		public void CreateComment(Comment comment)
		{
			_dbContext.Comment.Add(comment);
			_dbContext.SaveChanges();
		}

		public void UpdateComment(Comment comment)
		{
			_dbContext.Comment.Update(comment);
			_dbContext.SaveChanges();
		}

		public void DeleteCommentById(long commentId)
		{
			var comment = _dbContext.Comment.Find(commentId);
			if (comment != null)
			{
				_dbContext.Comment.Remove(comment);
				_dbContext.SaveChanges();
			}
		}

		public List<Comment> GetCommentsByDiaryEntry(int diaryEntryId)
		{
			return _dbContext.Comment
				.Where(c => c.DiaryEntryId == diaryEntryId)
				.ToList();
		}
	}
}