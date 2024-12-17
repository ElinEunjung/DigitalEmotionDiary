using DigitalEmotionDiary.Models;
using DigitalEmotionDiary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.UI
{
	public class LoginService
	{
		private readonly UserService _userService;

		private readonly long LoggedOutUserId = -1L;

		public LoginService(UserService userService)
		{
			_userService = userService;
		}

		public void RegisterUser()
		{
			Console.WriteLine("Enter new username: ");
			string NewUserName = Console.ReadLine();
			Console.WriteLine("Enter new  password: ");
			string NewPassWord = Console.ReadLine();
			Console.WriteLine("Enter new email address: ");
			string Email = Console.ReadLine();
			var result = _userService.RegisterUser(NewUserName, NewPassWord, Email);
			Console.WriteLine(result ? "User registered successfully!" : "Registration failed.");
		}

		public long Login(string username, string password)
		{
			User loggedInUser = _userService.Login(username,password);
			if (loggedInUser != null)
			{
				return loggedInUser.Id;
			}
			return LoggedOutUserId;
		}

		public long Logout()
		{
			return LoggedOutUserId;
		}

		public void UpdateProfile()
		{
			Console.Write("Enter your username (leave blank to keep current): ");
			var newUsername = Console.ReadLine();
			Console.Write("Enter new email (leave blank to keep current): ");
			var newEmail = Console.ReadLine();
			Console.Write("Enter new password (leave blank to keep current): ");
			var newPassword = Console.ReadLine();

			var result = _userService.UpdateUserProfile(newUsername, newEmail, newPassword);
			Console.WriteLine(result ? "Profile updated successfully!" : "Update failed.");
		}
	}
}
