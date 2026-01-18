namespace Dashboard.Services;

public static class FileHelpers
{
    public static readonly List<string> TextFileFormats =
    [
        // Basic Text & Documents
        ".txt", ".log", ".md", ".rtf", ".csv", ".tsv", 
    
        // Configuration & Data
        ".json", ".xml", ".yaml", ".yml", ".ini", ".conf", ".cfg", ".toml", ".env",
    
        // Web Development
        ".html", ".htm", ".css", ".scss", ".sass", ".js", ".ts", ".jsx", ".tsx", ".php", ".aspx",
    
        // Source Code
        ".cs", ".c", ".cpp", ".h", ".hpp", ".java", ".py", ".rb", ".swift", ".go", ".rs", ".kt", ".sh", ".bat", "lua"
    ];
    
    public static readonly List<string> AudioFileFormats =
    [
        // Standard Compressed (Lossy)
        ".mp3", ".aac", ".m4a", ".ogg", ".wma", ".opus",
    
        // High-Fidelity & Archival (Lossless)
        ".flac", ".alac", 
    
        // Uncompressed (Studio/Professional)
        ".wav", ".aiff", ".pcm",
    
        // Other & Niche Formats
        ".amr", ".aax", ".m4p", ".webm"
    ];
    
    public static readonly List<string> ArchiveFileFormats =
    [
        // Standard Universal Archives
        ".zip", ".zipx", ".7z", ".rar", 
    
        // Unix/Linux Distribution Formats
        ".tar", ".gz", ".tgz", ".bz2", ".xz", ".z", 
    
        // Software & Web Packages
        ".cab", ".msi", ".jar", ".war", ".apk", ".ipa",
    
        // Disc Images & Virtualization
        ".iso", ".img", ".vhd", ".vmdk",
    
        // Specialized & Comic Book Archives
        ".cbz", ".cbr", ".warc"
    ];

    public static readonly List<string> VideoFileFormats =
    [
        // Universal & Web Standards
        ".mp4", ".webm", ".m4v", ".mov",
    
        // High-Definition & Professional Archives
        ".mkv", ".avchd", ".m2ts", ".mts",
    
        // Legacy & System Specific
        ".avi", ".wmv", ".flv", ".f4v", ".swf",
    
        // Distribution & Broadcast
        ".mpg", ".mpeg", ".vob", ".3gp", ".3g2", ".mxf", ".asf", ".ts"
    ];
    
    public static readonly List<string> ImageFileFormats =
    [
        // Standard Web & Raster Formats
        ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".ico", ".tiff", ".tif",
    
        // Modern & High-Efficiency (Next-Gen)
        ".webp", ".avif", ".heic", ".heif", ".jxl",
    
        // Vector Graphics
        ".svg", ".svgz", ".eps", ".ai",
    
        // Professional & Editing Formats
        ".psd", ".psb", ".raw", ".cr2", ".nef", ".arw", ".pdf"
    ];
    
    public static IEnumerable<string> AllowedExtensions => TextFileFormats.Concat(AudioFileFormats).Concat(VideoFileFormats).Concat(ImageFileFormats);

    public static FileFormat GetFileCategory(string path)
    {
        string extension =  Path.GetExtension(path);

        if (TextFileFormats.Contains(extension)) return FileFormat.Text;
        if (ArchiveFileFormats.Contains(extension)) return FileFormat.Archive;
        if (VideoFileFormats.Contains(extension)) return FileFormat.Video;
        if (AudioFileFormats.Contains(extension)) return FileFormat.Audio;
        if (ImageFileFormats.Contains(extension)) return FileFormat.Image;
        return FileFormat.Other;
    }

    public enum FileFormat
    {
        Text,
        Archive,
        Video,
        Audio,
        Image,
        Other
    }
}