using DigitalEmotionDiary.Data.Repositories;
using DigitalEmotionDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.Services
{
	public class UserService
	{
		private readonly UserRepository _userRepository;

		public UserService(UserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public IEnumerable<User> GetAllUsers()
		{
			return _userRepository.GetAllUsers();
		}

		public bool IsEmailTaken(string email)
		{
			var users = _userRepository.GetAllUsers();
			return users.Any(u => u.Email == email);
		}

		public void CreateUser(User user)
		{
			_userRepository.CreateUser(user);
			_userRepository.SaveChanges();
		}

		public void UpdateUser(User user)
		{
			_userRepository.UpdateUser(user);
			_userRepository.SaveChanges();
		}

		public void DeleteUserById(long id)
		{
			var user = GetUserById(id);
			if (user != null)
			{
				_userRepository.DeleteUserById(id);
				_userRepository.SaveChanges();
			}
			else
			{
				throw new System.Exception($"User with ID {id} not found.");
			}
			
		}

		public User? GetUserById(long id)
		{
			return _userRepository.GetUserById(id);
		}

	}
}
