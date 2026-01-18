using Dashboard.Services;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Extensions;
using MudBlazor.Utilities;

namespace Dashboard.Components.Layout;

public partial class NavMenu
{
    [Inject] private DockerClient Client { get; set; }
    [Inject] private ThemeService ThemeService { get; set; }
    
    IList<ContainerListResponse>? _containers;

    private string GetNavLink(string container) => $"container/inspect/{container}";
    protected override async Task OnInitializedAsync()
    {
        _containers = await Client.Containers.ListContainersAsync(
            new ContainersListParameters()
            {
                Limit = 10,
            });
        await base.OnInitializedAsync();
    }

    private string IconFromStatus(string status)
    {
        switch (status)
        {
            case "running":
                return Icons.Material.Filled.PlayArrow;
                
            case "exited":
                return Icons.Material.Filled.Stop;
                
            case "restarting":
                return Icons.Material.Filled.Refresh;
                
            case "dead":
                return Icons.Material.Filled.Error;
            
            default:
                return Icons.Material.Filled.Info;
        }
    }

    private MudColor ColorFromStatus(string status)
    {
        
        Palette palette = ThemeService.CurrentPalette ?? throw new InvalidOperationException();
        switch (status)
        {
            case "running":
                return palette.Success;
                
            case "exited":
                return palette.Error;
                
            case "restarting":
                return palette.Secondary;
                
            case "dead":
                return palette.ErrorLighten;
            
            default:
                return palette.AppbarBackground;
        }
    }
    
    private string TextBackground(string status) => $"background: {ColorFromStatus(status).SetAlpha(.3)}";
}