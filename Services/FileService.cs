using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WpfCrudApp.Models;

namespace WpfCrudApp.Services
{
    public static class FileService
    {
        private static readonly string FilePath = "tasks.json";

        public static void Save(List<TaskItem> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(FilePath, json);
        }

        public static List<TaskItem> Load()
        {
            if (!File.Exists(FilePath))
                return new List<TaskItem>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
    }
}
