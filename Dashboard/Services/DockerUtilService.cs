using Docker.DotNet;
using Docker.DotNet.Models;

namespace Dashboard.Services;

public static class DockerUtilService
{
    public static async Task<Dictionary<MultiplexedStream.TargetStream, Stream>> Demultiplex(
        this MultiplexedStream multiplexedStream)
    {
        var stdinStream = new MemoryStream();
        var stdoutStream = new MemoryStream();
        var stderrStream = new MemoryStream();
    
        await multiplexedStream.CopyOutputToAsync(stdinStream, stdoutStream, stderrStream, CancellationToken.None);

        return new Dictionary<MultiplexedStream.TargetStream, Stream>
        {
            { MultiplexedStream.TargetStream.StandardIn, stdinStream },
            { MultiplexedStream.TargetStream.StandardOut, stdoutStream },
            { MultiplexedStream.TargetStream.StandardError, stderrStream },
        };
    }
}