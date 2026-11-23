using System.CommandLine;
using ConsoleVoorSkills.Options;
using ConsoleVoorSkills.Tasks;

namespace ConsoleVoorSkills.Commands;

public class ListCommand: Command
{
    private AllOption _allOption;
    private VerboseOption _verboseOption;
    
    public ListCommand() : base("list", "List all tasks")
    {
        _allOption = new AllOption();
        _verboseOption = new VerboseOption();
        
        Options.Add(_allOption);
        Options.Add(_verboseOption);
        
        SetAction(ListTasksAction);
        
    }

    private void ListTasksAction(ParseResult parseResult)
    {
        var showAll = parseResult.GetValue(_allOption);
        var verbose = parseResult.GetValue(_verboseOption);

        var tasks = TaskHelper.LoadTasks();
        var filtered = showAll ? tasks : tasks.Where(t => !t.IsComplete).ToList();

        if (filtered.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        foreach (var task in filtered)
        {
            var status = task.IsComplete ? "✓" : " ";
            Console.WriteLine($"  [{status}] {task.Id}: {task.Description}");
            if (verbose)
            {
                Console.WriteLine($"       Priority: {task.Priority}");
                if (task.Due is DateOnly dueDate)
                {
                    Console.WriteLine($"       Due: {dueDate}");
                }
            }
        }
    }
}