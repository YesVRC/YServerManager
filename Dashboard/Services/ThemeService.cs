using MudBlazor;

namespace Dashboard.Services;

public class ThemeService
{
    public bool IsDarkTheme { get; set; } = true;
    public MudTheme Theme { get; set; }
}