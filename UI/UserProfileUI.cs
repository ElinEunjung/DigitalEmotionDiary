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

		public void ShowUserProfileMenu()
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine(":::::: User Profile Menu :::::");
				Console.WriteLine("1. Register");
				Console.WriteLine("2. Log In");
				Console.WriteLine("3. Update Profile");
				Console.WriteLine("4. View Profile");
				Console.WriteLine("5. Log Out");
				Console.WriteLine("6. Return to Main Menu");
				Console.WriteLine("Choose an option: ");

				var choice = Console.ReadLine();
				switch (choice)
				{
					case "1":
						RegisterUser();
						break;
					case "2":
						Login();
						break;
					case "3":
						UpdateProfile();
						break;
					case "4":
						ViewProfile();
						break;
					case "5":
						LogOut();
						break;
					case "6":
						return;
					default:
						Console.WriteLine("Invalied option. Try again.");
						break;
				}

				Console.WriteLine("Press Enter to continue...");
				Console.ReadLine();
			}
		}

		public void RegisterUser()
		{
			Console.WriteLine("Type your new username: ");
			string NewUserName = Console.ReadLine();
			Console.WriteLine("Type your new password: ");
			string NewPassWord = Console.ReadLine();
			Console.WriteLine("Type your email: ");
			string Email = Console.ReadLine();
			_userService.RegisterUser(NewUserName, NewPassWord, Email);
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
		}

		public void ViewProfile()
		{
		}
		public void LogOut()
		{
		}
	}
}
