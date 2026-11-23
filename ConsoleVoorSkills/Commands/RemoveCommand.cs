using System.CommandLine;
using ConsoleVoorSkills.Arguments;
using ConsoleVoorSkills.Options;
using ConsoleVoorSkills.Tasks;

namespace ConsoleVoorSkills.Commands;

public class RemoveCommand : Command
{
    private TaskIdArgument _taskIdArgument;
    private VerboseOption _verboseOption;
    
    public RemoveCommand() : base("remove", "Remove a task")
    {
        _taskIdArgument = new TaskIdArgument();
        _verboseOption = new VerboseOption();
        
        Arguments.Add(_taskIdArgument);
        Options.Add(_verboseOption);
        
        SetAction(RemoveTaskAction);
    }

    private int RemoveTaskAction(ParseResult parseResult)
    {
        var id = parseResult.GetValue(_taskIdArgument);
        var verbose = parseResult.GetValue(_verboseOption);

        var tasks = TaskHelper.LoadTasks();
        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task is null)
        {
            Console.Error.WriteLine($"Task {id} not found.");
            return -1;
        }

        tasks.Remove(task);
        TaskHelper.SaveTasks(tasks);

        Console.WriteLine($"Removed task {id}: {task.Description}");
        if (verbose)
        {
            Console.WriteLine($"  Priority: {task.Priority}");
        }
        return 0;
    }
}