using MudBlazor;

namespace Dashboard.Services.LogParser;

public interface ILogParser
{
    public static abstract Color GetColorForLine(string line);
}