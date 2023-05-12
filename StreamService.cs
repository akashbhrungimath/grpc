using Google.Protobuf;
using Grpc.Core;
using GrpcClientStreaming;

namespace GrpcClientStreaming.Services
{
    public class StreamService : ClientStream.ClientStreamBase
    {
        private readonly ILogger<StreamService> _logger;
        public StreamService(ILogger<StreamService> logger)
        {
            _logger = logger;
        }

        public override async Task<Output> FindSum(IAsyncStreamReader<Inputs> requestStream, 
            ServerCallContext context)
        {
            var NumbersList = new List<int>();
            while(await requestStream.MoveNext())
            {
                var request = requestStream.Current;
                NumbersList.Add(request.Num);
            }
            return new Output { Sum = NumbersList.Sum() };
        }
    }
}