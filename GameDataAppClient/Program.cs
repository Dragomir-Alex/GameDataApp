using GameDataAPIClient;

namespace GameDataAppClient
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var client = new swaggerClient("https://localhost:7087", httpClient);

            var results = await client.GetItemAsync(1);

            Console.WriteLine(results.Name);

            Console.ReadKey();
        }
    }
}