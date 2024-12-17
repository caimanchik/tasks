using Serilog;

namespace BuildingBlocks.Logging;

public class FileOptions
{
    public bool Enabled { get; set; }
    public string Path { get; set; } = "logs/.txt";
    public string Interval { get; set; } = RollingInterval.Day.ToString();
}
