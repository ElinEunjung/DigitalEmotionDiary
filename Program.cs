

using DigitalEmotionDiary.Data;
using DigitalEmotionDiary.Data.Repositories;
using DigitalEmotionDiary.Services;
using DigitalEmotionDiary.UI;
using Microsoft.EntityFrameworkCore;

namespace DigitalEmotionDiary
{
	public class Program
	{
		static void Main(string[] args)
		{
			var dbContext = new DigitalEmotionDiaryDbContext();

			var userRepository = new UserRepository(dbContext);
			var userService = new UserService(userRepository);
			var diaryEntryRepository = new DiaryEntryRepository(dbContext);
			var diaryEntryService = new DiaryEntryService(diaryEntryRepository, userRepository);
			
			var diaryEntryUI = new DiaryEntryUI(diaryEntryService);
			var userProfileUI = new UserProfileUI(userService);

			bool isLoggedIn = false;

			var menu = new Menu(diaryEntryUI, userProfileUI, isLoggedIn);
			menu.Show();
		}

		
	}
}
