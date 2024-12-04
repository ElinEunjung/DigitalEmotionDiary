using DigitalEmotionDiary.Services;

namespace DigitalEmotionDiary
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var dbService = new DatabaseService();
			dbService.InitializeDatabase();

			if (dbService.TestConnection())
			{
				Console.WriteLine("Database connection successful!");
			}
			else
			{
				Console.WriteLine("Database connection failed!");
			}
		}
	}
}
