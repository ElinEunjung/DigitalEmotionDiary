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

		private static String GET_COMMAND = "GET";
    	private static String ADD_COMMAND = "ADD";
    	private static String QUIT_COMMAND = "QUIT";

    
    	private static Dictionary<String, Command> validCommands = new Dictionary<string, Command>
		{
        	{ADD_COMMAND, new Command(ADD_COMMAND, 3)},
        	{GET_COMMAND, new Command(GET_COMMAND, 1)},
        	{QUIT_COMMAND, new Command(QUIT_COMMAND, 0)}
    	};

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
			GetInputFromUser();
			Console.WriteLine("Exiting program...");
		}

		private void DisplayMainMenu()
		{
			Console.WriteLine("WRITE  - Write entry to Diary");
			Console.WriteLine("DELETE - Delete entry from Diary");
		}

		private void GetInputFromUser()
		{
			var UserCommand = Command.BlankCommand();
			while (!UserCommand.IsQuitCommand())
			{
				var userInput = Console.ReadLine();
				UserCommand = ParseInputAsCommand(userInput);

				if (CommandIsValid(UserCommand) && CommandHasCorrectNrOfArguments(UserCommand) && !UserCommand.IsQuitCommand())
				{
					ExecuteCommand(UserCommand);
				}
				else
				{
					Console.WriteLine("Error: Unrecognized command " + UserCommand.GetName());
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
			
		static void ExecuteCommand(Command command)
		{
			Console.WriteLine("Executing command: " + command.GetName() + " with arguments " + String.Join(" ", command.GetArguments()) + " ...");
		}

		static bool CommandIsValid(Command command)
		{
			return validCommands.ContainsKey(command.GetName());
		}

		static bool CommandHasCorrectNrOfArguments(Command command)
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
	}
}
