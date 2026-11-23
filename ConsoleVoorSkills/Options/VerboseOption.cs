using System.CommandLine;

namespace ConsoleVoorSkills.Options;

public class VerboseOption : Option<bool>
{
    private static string _name = "--verbose";
    
    public VerboseOption() : base(_name)
    {
        Description = "Show detailed output";
        Recursive = true;
    }
}