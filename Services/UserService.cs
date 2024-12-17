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

		public bool RegisterUser(string username, string email, string password)
		{
			var user = new User
			{
				UserName = username,
				Email = email,
				Password = password
			};
			try
			{
				_userRepository.CreateUser(user);
				_userRepository.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return false;
			}
		}

		public User? Login(string username, string password)
		{
			var user = _userRepository.GetUserByUsername(username);
			if (user == null)
			{
				Console.WriteLine($"User '{username}' does not exist.");
				return null;
			}

			Console.WriteLine($"User '{user.UserName}' found.");

			if (user.Password == password)
			{
				Console.WriteLine("Login Succeful.");
				return user;
			}
			Console.WriteLine("Login failed. Check your Username or Password.");
			return null;
		}

		public User? GetUserById(long id)
		{
			return _userRepository.GetUserById(id);
		}

		public long? GetUserIdByName(String username)
		{
			User user = _userRepository.GetUserByUsername(username);
			return user.Id;
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


		public bool UpdateUserProfile(string username, string password, string email)
		{
			var user = _userRepository.GetUserByUsername(username);
			try
			{
				if (user == null)
				{
					throw new ArgumentException("User not found.");
				}
				user.Password = password;
				user.Email = email;


				_userRepository.UpdateUser(user);
				_userRepository.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
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

		

	}
}
