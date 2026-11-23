namespace ConsoleVoorSkills.Tasks;

[System.Text.Json.Serialization.JsonSourceGenerationOptions(WriteIndented = true)]
[System.Text.Json.Serialization.JsonSerializable(typeof(List<TaskItem>))]
internal partial class TaskJsonContext : System.Text.Json.Serialization.JsonSerializerContext;
