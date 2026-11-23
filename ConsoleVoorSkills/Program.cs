using System.CommandLine;
using ConsoleVoorSkills.Commands;
using ConsoleVoorSkills.Options;

var rootCommand = new RootCommand("A simple task tracker CLI")
{
    Options = { new VerboseOption() },
    Subcommands = { new AddCommand(), new ListCommand(), new CompleteCommand(), new RemoveCommand()}
};

return rootCommand.Parse(args).Invoke();