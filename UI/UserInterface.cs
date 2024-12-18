using DigitalEmotionDiary.DTO;
using DigitalEmotionDiary.Models;
using DigitalEmotionDiary.Services;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace DigitalEmotionDiary.UI
{
	public class UserInterface
	{
		private readonly LoginService _loginService;
		private long _loggedInUserId = -1L;

		private const String WRITE_COMMAND = "WRITE";
    	private const String GET_COMMAND = "GET";
		private const String GET_ALL_COMMAND = "GET_ALL";
		private const String GET_BY_COLOR_COMMAND = "GET_BY_COLOR";
		private const String UPDATE_COMMAND = "UPDATE";
    	private const String DELETE_COMMAND = "DELETE";
		private const String HELP_COMMAND = "HELP";
		private const String LOGOUT_COMMAND = "LOGOUT";
    	private const String QUIT_COMMAND = "QUIT";


		private readonly DiaryEntryService _diaryEntryService;
    
    	private Dictionary<String, Command> validCommands = new Dictionary<string, Command>
		{
			{GET_COMMAND, new Command(GET_COMMAND, 1)},
			{GET_ALL_COMMAND, new Command(GET_ALL_COMMAND, 0)},
			{GET_BY_COLOR_COMMAND, new Command(GET_BY_COLOR_COMMAND, 1)},
			{UPDATE_COMMAND, new Command(UPDATE_COMMAND, 3)},
			{WRITE_COMMAND, new Command(WRITE_COMMAND, 4)},
			{DELETE_COMMAND, new Command(DELETE_COMMAND, 1)},
			{HELP_COMMAND, new Command(HELP_COMMAND, 0)},
			{LOGOUT_COMMAND, new Command(LOGOUT_COMMAND, 0)},
			{QUIT_COMMAND, new Command(QUIT_COMMAND, 0)}
    	};

		public UserInterface(
			LoginService loginService,
			DiaryEntryService diaryEntryService
		)
		{
			_loginService = loginService;
			_diaryEntryService = diaryEntryService;
		}

		public void Show()
		{
			while (true)
			{
				while(NotLoggedIn())
				{
					Login();
				}
				DisplayMainMenu();
				var shouldQuit = GetInputFromUser();
				if (shouldQuit)
				{
					break;
				}

			}
		}

		private void DisplayMainMenu()
		{
			Console.WriteLine("MENU");
			Console.WriteLine("-------------------------------------------------------------");
			Console.WriteLine("WRITE          - Write entry to Diary");
			Console.WriteLine("DELETE         - Delete entry from Diary");
			Console.WriteLine("GET            - Get a specific entry from the Diary");
			Console.WriteLine("GET_ALL        - Get all entries from the Diary");
			Console.WriteLine("GET_BY_COLOR   - Get entry by background color");
			Console.WriteLine("UPDATE         - Update diary entry(title,content or emotion)");
			Console.WriteLine("HELP           - Display this menu");
			Console.WriteLine("LOGOUT         - Logout current user");
			Console.WriteLine("QUIT           - Exit program");
			Console.WriteLine("-------------------------------------------------------------");
		}

		private bool GetInputFromUser()
		{
			var UserCommand = Command.BlankCommand();
			while (true)
			{
				Console.Write("COMMAND: ");
				var userInput = Console.ReadLine();
				UserCommand = ParseInputAsCommand(userInput);
				if (!UserCommand.IsBlankCommand() && CommandIsValid(UserCommand) && CommandHasCorrectNrOfArguments(UserCommand))
				{
					ExecuteCommand(UserCommand);
				}
				if (UserCommand.IsQuitCommand() || UserCommand.IsLogoutCommand())
				{
					break;
				}
			}
			if (UserCommand.IsQuitCommand())
			{
				return true;
			}
			return false;
		}


    	private Command ParseInputAsCommand(String userInput)
		{
			if (userInput.Length < 1)
			{
				return Command.BlankCommand();
			}
			var commandWithArguments = userInput.Split(";");
			String command = commandWithArguments[0];
			String[] arguments = [];
			if (commandWithArguments.Length > 1) {
				arguments = new String[commandWithArguments.Length - 1];
				Array.Copy(commandWithArguments, 1, arguments, 0, arguments.Length);
			}
			return new Command(command, arguments);
		}
			
		private void ExecuteCommand(Command command)
		{
			switch (command.GetName())
			{
				case WRITE_COMMAND :
					WriteDiaryEntry(command.GetArguments());
					break;
				case GET_COMMAND :
					GetDiaryEntry(command.GetArguments());
					break;
				case GET_ALL_COMMAND :
					GetAllDiaryEntries();
					break;
				case DELETE_COMMAND :
					DeleteDiaryEntry(command.GetArguments());
					break;
				case HELP_COMMAND :
					DisplayMainMenu();
					break;
				case GET_BY_COLOR_COMMAND :
					GetEntryByColor(command.GetArguments());
					break;
				case UPDATE_COMMAND :
					UpdateDiaryEntry(command.GetArguments());
					break;
				case LOGOUT_COMMAND :
					Logout();
					break;
				case QUIT_COMMAND :
					PrintQuitText();
					break;
				default:
					Console.WriteLine("Error, unknown command: " + command.GetName());
					break;
			}
		}

		private bool CommandIsValid(Command command)
		{
			if (!validCommands.ContainsKey(command.GetName()))
			{
				Console.WriteLine("Error: Unrecognized command " + command.GetName());
				return false;
			}
			if (command.IsUpdateCommand())
			{
				String updateOption = command.GetArguments()[1];
				if (!new String[] {"TITLE", "CONTENT", "EMOTION"}.Any(updateOption.Contains))
				{
					Console.WriteLine("Error: Invalid UPDATE option: " + updateOption);
					return false;
				}
				
			}
			return true;
		}

		private bool CommandHasCorrectNrOfArguments(Command command)
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

		private void WriteDiaryEntry(String[] arguments)
		{
			DiaryEntryDTO entryDTO = new DiaryEntryDTO();
			entryDTO.Title = arguments[0];
			entryDTO.Content = arguments[1];
			entryDTO.IsPublic = arguments[2] == "true";
			entryDTO.EmotionId = int.Parse(arguments[3]);

			_diaryEntryService.PublishDiaryEntry(_loggedInUserId, entryDTO);
		}

		private void GetDiaryEntry(String[] arguments)
		{
			var entry = _diaryEntryService.GetDiaryEntry((long) _loggedInUserId, long.Parse(arguments[0]));
			printEntry(entry);
		}

		private void GetAllDiaryEntries()
		{
			var entries = _diaryEntryService.GetAllDiaryEntriesAccessibleToUser((long) _loggedInUserId);
			printEntries(entries);
		}

		private void GetEntryByColor(String[] arguments)
		{
			var entriesByColor = _diaryEntryService.GetEntryByColor(_loggedInUserId, arguments[0]);
			printEntries(entriesByColor);
		}

		private void UpdateDiaryEntry(String[] arguments)
		{
			long diaryEntryId = long.Parse(arguments[0]);
			DiaryEntry existingEntry = _diaryEntryService.GetDiaryEntry(_loggedInUserId, diaryEntryId);
			if (existingEntry == null) {
				Console.WriteLine("Error: Update failed. Could not find entry with id " + diaryEntryId + " on user " + _loggedInUserId);
				return;
			}
			DiaryEntryDTO entryDTO = DiaryEntryDTO.FromDiaryEntry(existingEntry);

			switch (arguments[1])
			{
				case "TITLE" :
					entryDTO.Title = arguments[2];
					break;
				case "CONTENT" :
					entryDTO.Content = arguments[2];
					break;
				case "EMOTION" :
					entryDTO.EmotionId = int.Parse(arguments[2]);
					break;
			}
			_diaryEntryService.UpdateDiaryEntry(_loggedInUserId, diaryEntryId, entryDTO);
		}

		private void DeleteDiaryEntry(String[] arguments)
		{
			_diaryEntryService.DeleteDiaryEntryByUserIdAndEntryId(_loggedInUserId, long.Parse(arguments[0]));
		}

		private void Login()
		{
			Console.Write("Please log in. Enter your username: ");
			string username = Console.ReadLine();
			Console.Write("Enter your password: ");
			string password = Console.ReadLine();
			_loggedInUserId = _loginService.Login(username, password);
		}

		private void Logout()
		{
			_loggedInUserId = _loginService.Logout();
		}

		private bool NotLoggedIn()
		{
			return _loggedInUserId == -1L;
		}

		private void PrintQuitText()
		{	
			Console.WriteLine("Exiting program...");
		}

		private void printEntries(List<DiaryEntry> entries)
		{
			foreach (DiaryEntry entry in entries)
			{
				printEntry(entry);
			}
		}

		private void printEntry(DiaryEntry entry)
		{
			if (entry != null)
			{
				Console.WriteLine("ENTRY[" + entry.CreatedAt + "]\nTitle: " + entry.Title + "\nContent: " + entry.Content + "\n");
			}
		}
	}
}
