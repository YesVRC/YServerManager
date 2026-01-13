namespace Dashboard.Services;

public static class DirectoryHelpers
{
    private static readonly string[] ExtensionsIHate =
    [
        ".bin",
        ".so",
        ".class",
        ".sock"
    ];
    public static IEnumerable<String> GetFlatDirectory(string path)
    {
        return Directory
            .EnumerateFileSystemEntries(path, "*", SearchOption.TopDirectoryOnly)
            .Where(x => !ExtensionsIHate.Any(x.EndsWith));
    }
}