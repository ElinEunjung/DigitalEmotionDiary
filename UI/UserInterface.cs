using DigitalEmotionDiary.Models;
using DigitalEmotionDiary.Services;

namespace DigitalEmotionDiary.UI
{
	public class UserInterface
	{
		private readonly DiaryEntryUI _diaryEntryUI;
		private readonly LoginService _loginService;
		private readonly UserService _userService;
		private long _loggedInUserId = -1L;

		private const String WRITE_COMMAND = "WRITE";
    	private const String GET_COMMAND = "GET";
		private const String GET_ALL_COMMAND = "GET_ALL";
		
    	private const String DELETE_COMMAND = "DELETE";
    	private const String QUIT_COMMAND = "QUIT";


		private readonly DiaryEntryService _diaryEntryService;
    
    	private Dictionary<String, Command> validCommands = new Dictionary<string, Command>
		{
			{GET_ALL_COMMAND, new Command(GET_ALL_COMMAND, 0)},
        	{GET_COMMAND, new Command(GET_COMMAND, 1)},
        	{WRITE_COMMAND, new Command(WRITE_COMMAND, 1)},
			{DELETE_COMMAND, new Command(DELETE_COMMAND, 2)},
        	{QUIT_COMMAND, new Command(QUIT_COMMAND, 0)}
    	};

		public UserInterface(
			DiaryEntryUI diaryEntryUI,
			LoginService loginService,
			UserService userService,
			DiaryEntryService diaryEntryService
		)
		{
			_diaryEntryUI = diaryEntryUI;
			_loginService = loginService;
			_userService = userService;
			_diaryEntryService = diaryEntryService;
		}

		public void Show()
		{
			while(_loggedInUserId == -1L)
			{
				Console.WriteLine("Please log in. Enter your username : ");
				string username = Console.ReadLine();
				Console.WriteLine("Enter your password : ");
				string password = Console.ReadLine();
				_loggedInUserId = _loginService.Login(username, password);
			}

			DisplayMainMenu();
			GetInputFromUser();
			Console.WriteLine("Exiting program...");
		}

		private void DisplayMainMenu()
		{
			Console.WriteLine("WRITE   - Write entry to Diary");
			Console.WriteLine("DELETE  - Delete entry from Diary");
			Console.WriteLine("GET     - Get a specific entry from the Diary");
			Console.WriteLine("GET_ALL - Get all entries from the Diary");
			Console.WriteLine("QUIT    - Exit program");
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
					GetDiaryEntry(command.GetArguments());
					break;
				case GET_ALL_COMMAND :
					GetAllDiaryEntries();
					break;
				case DELETE_COMMAND :
				GetDiaryEntry(command.GetArguments());
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

		public void GetDiaryEntry(String[] arguments)
		{
			var entry = _diaryEntryService.GetDiaryEntry((long) _loggedInUserId, long.Parse(arguments[0]));
			printEntry(entry);
		}

		public void GetAllDiaryEntries()
		{
			var entries = _diaryEntryService.GetAllDiaryEntriesAccessibleToUser((long) _loggedInUserId);
			foreach (DiaryEntry entry in entries)
			{
				printEntry(entry);
			}
		}

		public void DeleteDiaryEntry(String[] arguments)
		{
			_diaryEntryService.DeleteDiaryEntryByUserIdAndEntryId(long.Parse(arguments[0]), long.Parse(arguments[1]));
		}

		private void printEntry(DiaryEntry entry)
		{
			if (entry != null)
			{
				Console.WriteLine("ENTRY[" + entry.CreatedAt + "]: " + entry.Content);
			}
		}
	}
}
