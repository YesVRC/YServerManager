using MudBlazor;

namespace Dashboard.Services.LogParser;

public class MinecraftLogParser : ILogParser
{
    public static Color GetColorForLine(string line)
    {
        if (line.Contains("INFO")) return Color.Info;
        if (line.Contains("WARN") || line.Contains("FATAL") || line.Contains("Exception") || line.StartsWith("at")) return Color.Error;
        return Color.Primary;
    }
}