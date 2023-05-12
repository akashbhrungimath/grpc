using Grpc.Core;
using System.Reflection.Emit;

namespace BidirectionalStreamingServer2.Services
{
    public class StreamingService : StartStreaming.StartStreamingBase
    {
        private readonly ILogger <StreamingService> _logger;

        public StreamingService(ILogger <StreamingService> logger)
        {
            _logger = logger;
        }

        public override async Task FindSum(IAsyncStreamReader<Inputs> requestStream, IServerStreamWriter<Outputs> responseStream, ServerCallContext context)
        {
            var output = new Outputs { Sum = 0 };
            while (await requestStream.MoveNext())
            {
                var input = requestStream.Current;
                output.Sum += input.Num;
            }
            while (!context.CancellationToken.IsCancellationRequested)
            {
                await responseStream.WriteAsync(output);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
