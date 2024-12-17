using Microsoft.VisualBasic;

class Command
{
    String _name;
    String[] _arguments;
    int _nrOfArguments;

    public Command(String name, String[] arguments)
    {
        _name = name;
        _arguments = arguments;
        _nrOfArguments = _arguments.Length;
    }
    
    public Command(String name, int nrOfArguments)
    {
        _name = name;
        _nrOfArguments = nrOfArguments;
    }

    public bool IsQuitCommand()
    {
        return _name == "QUIT";
    }

    public bool isLogoutCommand()
    {
        return _name == "LOGOUT";
    }
    
    public override bool Equals(object obj)
    {        
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        Command otherCommand = (Command) obj;

        return otherCommand._name == _name && otherCommand._nrOfArguments == _nrOfArguments;
    }

    public String GetName()
    {
        return _name;
    }

    public int GetNrOfArguments()
    {
        return _nrOfArguments;
    }

    
    public String[] GetArguments()
    {
        return _arguments;
    }

    public static Command BlankCommand()
    {
        return new Command("", []);
    }
    
}