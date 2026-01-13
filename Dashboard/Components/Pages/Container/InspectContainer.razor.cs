using System.Text.RegularExpressions;
using Dashboard.Services.LogParser;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dashboard.Components.Pages.Container;

public partial class InspectContainer
{
    [Parameter] public required string Id { get; set; }
    
    [Inject] private DockerClient Client { get; set; } = null!;

    Func<string, Color> _parser = null!;

    private string _logs = "";

    protected override async Task OnInitializedAsync()
    {
        var result = await Client.Containers.InspectContainerAsync(Id);
        if (result.Image.Contains("zomboid"))
        {
        }
        else _parser = MinecraftLogParser.GetColorForLine;
        
        //Task.Run(ReadContainerLogs);
        
        await base.OnInitializedAsync();
    }


    private async Task ReadContainerLogs()
    {
        var logsParameters = new ContainerLogsParameters()
        {
            ShowStdout = true,
            Tail = "100"
        };
            
        CancellationToken token = CancellationToken.None;
        int batchCount = 0;
        int batchSize = 100;
        Progress<string> progress = new Progress<string>((value) =>
        {
            //Console.WriteLine(value);
            var regex = new Regex(@"\x1b\[[0-9;]*[mGKHFT]");
            //value = new string(value.Where(c => !char.IsControl(c)).ToArray());
            value = regex.Replace(value, string.Empty);
            _logs += value + '\n';
            InvokeAsync(StateHasChanged);
            batchCount++;
            // if (batchCount >= batchSize)
            // {
            //     InvokeAsync(StateHasChanged);
            //     batchCount = 0;
            // }
        });
        await Client.Containers.GetContainerLogsAsync(Id, logsParameters, progress, token);
    }
}