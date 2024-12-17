using DigitalEmotionDiary.Models;
using DigitalEmotionDiary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalEmotionDiary.UI
{
	public class DiaryEntryUI
	{
		private readonly DiaryEntryService _diaryEntryService;

		public DiaryEntryUI(DiaryEntryService diaryEntryService)
		{
			_diaryEntryService = diaryEntryService;
		}


		public void ShowDiaryEntryMenu()
		{
			while (true)
			{
				Console.Clear();
				Console.WriteLine(":::::: Diary Entry Menu :::::");
				Console.WriteLine("1. Write Diary");
				Console.WriteLine("2. Delete Diary");
				Console.WriteLine("3. Update Diary");
				Console.WriteLine("4. Search Diary");
				Console.WriteLine("5. Return to Main Menu");
				Console.WriteLine("Choose an option: ");

				var choice = Console.ReadLine();
				switch (choice)
				{
					case "1":
						WriteDiaryEntry();
						break;
					case "2":
						DeleteDiaryEntry();
						break;
					case "3":
						UpdateDiaryEntry();
						break;
					case "4":
						SearchDiaryEntry();
						break;
					case "5":
						return;
					default:
						Console.WriteLine("Invalied option. Try again.");
						break;
				}

				Console.WriteLine("Press Enter to continue...");
				Console.ReadLine();
			}
		}
		public void WriteDiaryEntry()
		{
			// WriteDiaryEntry logic
		}

		public void DeleteDiaryEntry()
		{
			// DeleteDiaryEntry logic
		}

		public void UpdateDiaryEntry()
		{
			// UpdateDiaryEntry logic
		}

		public void SearchDiaryEntry()
		{
			// SearchDiaryEntry logic
		}
	}
}
