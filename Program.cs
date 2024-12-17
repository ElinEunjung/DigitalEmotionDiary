

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
			var loginService = new LoginService(userService);

			var userInterface = new UserInterface(diaryEntryUI, loginService, userService, diaryEntryService);
			userInterface.Show();
		}	
	}
}
