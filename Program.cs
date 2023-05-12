// See https://aka.ms/new-console-template for more information
using System;
using GrpcClientStreaming;
using System.Threading;
using Grpc.Net.Client;
namespace StreamerClient
{
    class ClientAddition
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5290");
            var client = new ClientStream.ClientStreamClient(channel);
            using var num = client.FindSum();
            foreach (var item in new[] { 1, 2, 3, 4 })
            {
                Console.WriteLine("Input number Given = " + item);
                await num.RequestStream.WriteAsync(new Inputs { Num = item });
            }
            await num.RequestStream.CompleteAsync();
            var response = await num.ResponseAsync;
            Console.WriteLine(response.Sum);
            Console.ReadLine();
        }
    }
}
