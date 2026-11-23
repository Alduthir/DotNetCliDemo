using System.Text.Json;

namespace ConsoleVoorSkills.Tasks;

public class TaskHelper
{
    static string GetTaskFilePath() => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "taskcli-sample",
        "tasks.json");

    public static List<TaskItem> LoadTasks()
    {
        var path = GetTaskFilePath();
        if (!File.Exists(path))
        {
            return [];
        }

        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize(json, TaskJsonContext.Default.ListTaskItem) ?? [];
    }

    public static void SaveTasks(List<TaskItem> tasks)
    {
        var path = GetTaskFilePath();
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        var json = JsonSerializer.Serialize(tasks, TaskJsonContext.Default.ListTaskItem);
        File.WriteAllText(path, json);
    }
}