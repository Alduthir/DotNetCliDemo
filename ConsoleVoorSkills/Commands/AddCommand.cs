using System.CommandLine;
using ConsoleVoorSkills.Arguments;
using ConsoleVoorSkills.Options;
using ConsoleVoorSkills.Tasks;

namespace ConsoleVoorSkills.Commands;

public class AddCommand : Command
{
    private readonly DescriptionArgument _descriptionArgument;
    private readonly PriorityOption _priorityOption;
    private readonly DueOption _dueOption;
    private readonly VerboseOption _verboseOption;
    
    public AddCommand() : base("add", "Add a new Task")
    {
        _descriptionArgument = new DescriptionArgument();
        _priorityOption = new PriorityOption();
        _dueOption = new DueOption();
        _verboseOption = new VerboseOption();
        
        Arguments.Add(_descriptionArgument);
        Options.Add(_priorityOption);
        Options.Add(_dueOption);
        Options.Add(_verboseOption);
        
        SetAction(AddAction);
    }

    private void AddAction(ParseResult parseResult)
    {
        var description = parseResult.GetValue(_descriptionArgument)!;
        var priority = parseResult.GetValue(_priorityOption);
        var due = parseResult.GetValue(_dueOption);
        var verbose = parseResult.GetValue(_verboseOption);

        var tasks = TaskHelper.LoadTasks();
        var id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
        var task = new TaskItem(id, description, priority, due, false);
        tasks.Add(task);
        TaskHelper.SaveTasks(tasks);
        
        Console.WriteLine($"Added task {id}: {description}");
        if (verbose)
        {
            Console.WriteLine($"    Priority: {priority}");
            if (due is not null)
            {
                Console.WriteLine($"    Due Date: {due}");
            }
        }
    }
}