using DigitalEmotionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Data.Repositories
{
	public class UserRepository
	{
		private readonly DigitalEmotionDiaryDbContext _dbContext;

		public UserRepository(DigitalEmotionDiaryDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public User? GetUserById(long id)
		{
			return _dbContext.User.FirstOrDefault(u => u.Id == id);
		}

		public IEnumerable<User> GetAllUsers()
		{
			return _dbContext.User.ToList();
		}

		
		public void CreateUser(User user)
		{
			_dbContext.User.Add(user);
		}

		public void UpdateUser(User user)
		{
			_dbContext.User.Update(user);
		}

		public void DeleteUserById(long id)
		{
			var user = _dbContext.User.FirstOrDefault(u => u.Id == id);
			if (user != null)
			{
				_dbContext.User.Remove(user);
			}
			else
			{
				throw new System.Exception($"User with ID {id} not found.");
			}
		}

		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}
	}
}
