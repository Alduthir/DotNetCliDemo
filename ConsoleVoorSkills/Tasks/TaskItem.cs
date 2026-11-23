using ConsoleVoorSkills.Enums;

namespace ConsoleVoorSkills.Tasks;

public record TaskItem(int Id, string Description, Priority Priority, DateOnly? Due, bool IsComplete);