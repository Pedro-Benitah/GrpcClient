using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using Calculator; // Namespace gerado pelo .proto

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Conectando ao servidor (substitua pelo IP público do servidor, se necessário)
            var channel = GrpcChannel.ForAddress("http://localhost:50051");

            // Criar o cliente gRPC
            var client = new Calculator.Calculator.CalculatorClient(channel);

            // Criar a requisição com os números a somar
            var request = new SumRequest { A = 7, B = 5 };

            // Chamar o método Sum no servidor
            var response = await client.SumAsync(request);

            // Exibir o resultado
            Console.WriteLine($"O resultado da soma é: {response.Result}");

            // Fechar o canal
            await channel.ShutdownAsync();
        }
    }
}
