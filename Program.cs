// See https://aka.ms/new-console-template for more information
using System;
using Grpc.Net.Client;
using GrpcServerStreaming;
using System.Threading;
using Grpc.Core;

namespace ServerStreamingClient
{
    class ClientMultiple
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5021");
            var client = new ServerStream.ServerStreamClient(channel);
            var num = Convert.ToInt32(Console.ReadLine());
            var input = new InputNum { Num = num };
            var CancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            using var stream = client.GetMultiples(input, cancellationToken: 
                CancellationToken.Token);
            try
            {
                await foreach (var item in 
                    stream.ResponseStream.ReadAllAsync(CancellationToken.Token))
                {
                    Console.WriteLine(item.Multiple);
                }
            }
            catch (RpcException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press Enter to exit......");
            Console.ReadLine();
        }
    }
}
