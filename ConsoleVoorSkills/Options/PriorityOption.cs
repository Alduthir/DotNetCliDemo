using System.CommandLine;
using ConsoleVoorSkills.Enums;

namespace ConsoleVoorSkills.Options;

public class PriorityOption : Option<Priority>
{
    public PriorityOption() : base("--priority")
    {
        Description = "Task priority level";
        DefaultValueFactory = _ => Priority.Low;
    }
}