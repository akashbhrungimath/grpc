using Grpc.Core;
using GrpcServerStreaming;

namespace GrpcServerStreaming.Services
{
    public class ServerStreamingService : ServerStream.ServerStreamBase
    {
        private readonly ILogger<ServerStreamingService> _logger;
        public ServerStreamingService(ILogger<ServerStreamingService> logger)
        {
            _logger = logger;
        }

        public override async Task GetMultiples(InputNum request, IServerStreamWriter<SendMultiples> responseStream, ServerCallContext context)
        {
            int multiplier = 1;
            while(!context.CancellationToken.IsCancellationRequested)
            {
                var output = new SendMultiples { Multiple = 0};
                output.Multiple = request.Num * multiplier++;
                await responseStream.WriteAsync(output);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}