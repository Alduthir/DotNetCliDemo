using System.CommandLine;

namespace ConsoleVoorSkills.Arguments;

public class TaskIdArgument : Argument<int>
{
    public TaskIdArgument() : base("id")
    {
        Description = "Task id";
    }
}