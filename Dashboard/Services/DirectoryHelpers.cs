namespace Dashboard.Services;

public static class DirectoryHelpers
{
    private static readonly List<string> ExtensionsIHate =
    [
        ".bin",
        ".so",
        ".class",
        ".sock",
        ".exe",
        ".dat"
    ];

    public static IEnumerable<String> GetFlatDirectory(string path)
    {
        return Directory
            .EnumerateFileSystemEntries(path, "*", SearchOption.TopDirectoryOnly)
            .Where(x => FileHelpers.AllowedExtensions.Any(ext =>
                ext.Equals(Path.GetExtension(x), StringComparison.OrdinalIgnoreCase)));
    }
}