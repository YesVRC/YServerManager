using Dashboard.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dashboard.Components.Controls;

public partial class DirectoryTreeView
{
    [Parameter] public string? Path { get; set; }
    [Parameter] public bool FullPath { get; set; }
    
    [CascadingParameter] public required FileOverlayComponent FileOverlayComponent { get; set; }
    
    IEnumerable<string>? _files;
    private bool isExpanded = false;

    protected override async Task OnParametersSetAsync()
    {
        _files = null;
        StateHasChanged();
        base.OnParametersSetAsync();
    }

    public void Refresh()
    {
        StateHasChanged();
    }

    private void OnClickGetFiles(bool expanded)
    {
        if ((Path != null || _files != null) && expanded) _files = DirectoryHelpers.GetFlatDirectory(Path);
    }

    private string IconFromFileType(string file) => FileHelpers.GetFileCategory(file) switch
    {
        FileHelpers.FileFormat.Text => Icons.Material.Filled.InsertDriveFile,
        FileHelpers.FileFormat.Archive => Icons.Material.Filled.FolderZip,
        FileHelpers.FileFormat.Audio => Icons.Material.Filled.AudioFile,
        FileHelpers.FileFormat.Video => Icons.Material.Filled.VideoFile,
        FileHelpers.FileFormat.Other => Icons.Material.Filled.Info,
        FileHelpers.FileFormat.Image => Icons.Material.Filled.Image,
        _ => Icons.Material.Filled.Error
    };

    private void OpenFileOverlay(string path)
    {

    }

    private async Task OnClickEditFile(string file)
    {
        await FileOverlayComponent.OpenFile(file);
    }
}