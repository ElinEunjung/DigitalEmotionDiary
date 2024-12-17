using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.UI
{
	public class Menu
	{
		private readonly DiaryEntryUI _diaryEntryUI;
		private readonly UserProfileUI _userProfileUI;
		private bool _isLoggedIn = false;

		public Menu(DiaryEntryUI diaryEntryUI, UserProfileUI userProfileUI, bool isLoggdIn)
		{
			_diaryEntryUI = diaryEntryUI;
			_userProfileUI = userProfileUI;
			_isLoggedIn = isLoggdIn;
		}

		public void Show()
		{
			while(!_isLoggedIn)
			{
				Console.WriteLine("Please log in. Enter your username : ");
				string username = Console.ReadLine();
				Console.WriteLine("Enter your password : ");
				string password = Console.ReadLine();

				if (_userProfileUI.Login(username, password))
				{
					_isLoggedIn = true;
				}
			}

			DisplayMainMenu();
		}

		private void DisplayMainMenu()
		{
			Console.WriteLine("1. Write Diary");
			Console.WriteLine("2. Delete Diary");
		}
	}
}
