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

    private string ColorFromStatus(string status)
    {
        
        //Palette palette = ThemeService.GetState(x => x.CurrentPalette) ?? throw new InvalidOperationException();
        switch (status)
        {
            case "running":
                return "success";
                
            case "exited":
                return "error";
                
            case "restarting":
                return "secondary";
                
            case "dead":
                return "error-lighten";
            
            default:
                return "appbar-background";
        }
    }
    
    private string TextBackground(string status) => $"background: rgb(from var(--mud-palette-{ColorFromStatus(status)}) r g b / .1";
}