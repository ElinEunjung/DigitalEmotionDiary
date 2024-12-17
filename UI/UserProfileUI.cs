using DigitalEmotionDiary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.UI
{
	public class UserProfileUI
	{
		private readonly UserService _userService;

		public UserProfileUI(UserService userService)
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

		public void Login()
		{
			Console.WriteLine("Enter username: ");
			string username = Console.ReadLine();
			Console.WriteLine("Enter password: ");
			string password = Console.ReadLine();

			if (Login(username, password))
			{
				Console.WriteLine("Login successful.");
			}
			else
			{
				Console.WriteLine("Login failed.");
			}
		}

		public bool Login(string username, string password)
		{
			return _userService.Login(username,password);
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
