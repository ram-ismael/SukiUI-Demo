using System;
using System.IO;
using System.Text.Json;

namespace SukiUI_Demo.Helpers;

public class ThemeSettings
{
    public bool IsDarkMode { get; set; } = true;
}

public static class ThemeHelper
{
    private static readonly string FilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "SukiUITest", "settings.json");

    public static ThemeSettings Load()
    {
        try
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<ThemeSettings>(json) ?? new ThemeSettings();
            }
        }
        catch { /* arquivo corrompido, ignora e usa default */ }

        return new ThemeSettings();
    }

    public static void Save(ThemeSettings settings)
    {
        var dir = Path.GetDirectoryName(FilePath)!;
        Directory.CreateDirectory(dir);
        var json = JsonSerializer.Serialize(settings);
        File.WriteAllText(FilePath, json);
    }
}