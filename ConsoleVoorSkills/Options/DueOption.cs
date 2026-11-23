using System.CommandLine;
using System.Globalization;

namespace ConsoleVoorSkills.Options;

public class DueOption : Option<DateOnly?>
{
    public DueOption() : base("--due")
    {
        Description = "Due date (dd-mm-yyyy)";
        CustomParser = result =>
        {
            try
            {
                return DateOnly.Parse(result.Tokens.First().ToString(), new CultureInfo("nl_NL"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        };
    }
}