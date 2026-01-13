using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.AspNetCore.Components;

namespace Dashboard.Components.Pages;

public partial class Home
{
    [Inject]
    DockerClient Client { get; set; }
    
    
    IList<ContainerListResponse>? _containers;
    private bool _hidePosition;
    private bool _loading;

    private string GetNavLink(string container)
    {
        return $"container/{container}";
    }

    private string GetContainerName(ContainerListResponse container)
    {
        return container.Names[0].Split('/')[1];
    }
    protected override async Task OnInitializedAsync()
    {
        _containers = await Client.Containers.ListContainersAsync(
            new ContainersListParameters()
            {
                Limit = 10,
            });

        await base.OnInitializedAsync();
    }

}