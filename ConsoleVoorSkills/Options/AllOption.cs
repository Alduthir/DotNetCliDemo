using System.CommandLine;

namespace ConsoleVoorSkills.Options;

public class AllOption : Option<bool>
{
    public AllOption() : base("--all")
    {
        Description = "Include completed tasks";
    }
}