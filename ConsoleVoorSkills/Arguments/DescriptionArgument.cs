using System.CommandLine;

namespace ConsoleVoorSkills.Arguments;

public class DescriptionArgument : Argument<string>
{
    public DescriptionArgument() : base("description")
    {
        Description = "Task Description";
    }
}