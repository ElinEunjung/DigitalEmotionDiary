using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalEmotionDiary.Models;
using DigitalEmotionDiary.Services;

namespace DigitalEmotionDiary.UI
{
	public class Menu
	{
		private readonly DiaryEntryUI _diaryEntryUI;
		private readonly UserProfileUI _userProfileUI;
		private bool _isLoggedIn = false;

		private const String WRITE_COMMAND = "WRITE";
    	private const String GET_COMMAND = "GET";
		
    	private const String DELETE_COMMAND = "DELETE";
    	private const String QUIT_COMMAND = "QUIT";


		private readonly DiaryEntryService _diaryEntryService;
    
    	private Dictionary<String, Command> validCommands = new Dictionary<string, Command>
		{
        	{GET_COMMAND, new Command(GET_COMMAND, 3)},
        	{WRITE_COMMAND, new Command(WRITE_COMMAND, 1)},
			{DELETE_COMMAND, new Command(DELETE_COMMAND, 2)},
        	{QUIT_COMMAND, new Command(QUIT_COMMAND, 0)}
    	};

		public Menu(DiaryEntryUI diaryEntryUI, UserProfileUI userProfileUI, DiaryEntryService diaryEntryService, bool isLoggdIn)
		{
			_diaryEntryUI = diaryEntryUI;
			_userProfileUI = userProfileUI;
			_isLoggedIn = isLoggdIn;
			_diaryEntryService = diaryEntryService;
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
			GetInputFromUser();
			Console.WriteLine("Exiting program...");
		}

		private void DisplayMainMenu()
		{
			Console.WriteLine("WRITE  - Write entry to Diary");
			Console.WriteLine("DELETE - Delete entry from Diary");
			Console.WriteLine("GET    - Get entries from Diary");
			Console.WriteLine("QUIT   - Exit program");
		}

		private void GetInputFromUser()
		{
			var UserCommand = Command.BlankCommand();
			while (!UserCommand.IsQuitCommand())
			{
				var userInput = Console.ReadLine();
				UserCommand = ParseInputAsCommand(userInput);
				if (UserCommand.IsQuitCommand())
				{
					break;
				}
				if (CommandIsValid(UserCommand) && CommandHasCorrectNrOfArguments(UserCommand))
				{
					ExecuteCommand(UserCommand);
				}
			}
		}


    	static Command ParseInputAsCommand(String userInput)
		{
			if (userInput.Length < 1)
			{
				return Command.BlankCommand();
			}
			var commandWithArguments = userInput.Split(" ");
			String command = commandWithArguments[0];
			String[] arguments = [];
			if (commandWithArguments.Length > 1) {
				arguments = new String[commandWithArguments.Length - 1];
				Array.Copy(commandWithArguments, 1, arguments, 0, arguments.Length);
			}
			return new Command(command, arguments);
		}
			
		void ExecuteCommand(Command command)
		{
			Console.WriteLine("Executing command: " + command.GetName() + " with arguments " + String.Join(" ", command.GetArguments()) + " ...");
			switch (command.GetName())
			{
				case WRITE_COMMAND :
					WriteDiaryEntry(command.GetArguments());
					break;
				case GET_COMMAND :
					GetDiaryEntries(command.GetArguments());
					break;
				case DELETE_COMMAND :
					GetDiaryEntries(command.GetArguments());
					break;
				default:
					Console.WriteLine("Error, unknown command: " + command.GetName());
					break;
			}
		}

		bool CommandIsValid(Command command)
		{
			if (!validCommands.ContainsKey(command.GetName()))
			{
				Console.WriteLine("Error: Unrecognized command " + command.GetName());
				return false;
			}
			return true;
		}

		bool CommandHasCorrectNrOfArguments(Command command)
		{
			var nrOfArgumentsInGivenCommand = command.GetNrOfArguments();
			var nrOfArgumenntsInValidCommand = validCommands[command.GetName()].GetNrOfArguments();
			if (nrOfArgumentsInGivenCommand != nrOfArgumenntsInValidCommand)
			{
				Console.WriteLine("Number of arguments given"  + "(" + nrOfArgumentsInGivenCommand + ")" + "in command " + command.GetName() + " differ from the valid number of arguments: " + nrOfArgumenntsInValidCommand);
				return false;
			}
			return true;
		}


		public void WriteDiaryEntry(String[] arguments)
		{
			_diaryEntryService.PublishDiaryEntry(long.Parse(arguments[0]), null);
		}

		public void GetDiaryEntries(String[] arguments)
		{
			var entries = _diaryEntryService.GetAllDiaryEntries();
			foreach (DiaryEntry entry in entries)
			{
				Console.WriteLine("ENTRY: " + entry.Content +  " " + entry.CreatedAt);
			}
		}

		public void DeleteDiaryEntry(String[] arguments)
		{
			_diaryEntryService.DeleteDiaryEntryByUserIdAndEntryId(long.Parse(arguments[0]), long.Parse(arguments[1]));
		}
	}
}
