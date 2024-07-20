using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class UserDataManager
{
    private const string FilePath = "users.json";

    public static void SaveUsers(List<User> users)
    {
        var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

    public static List<User> LoadUsers()
    {
        if (!File.Exists(FilePath))
        {
            return new List<User>();
        }

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
    }
}
