using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientStatus
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://the-one-api.dev/v2/book/");
            request.Headers.Add("Authorization", $"Bearer _7O4nscQGh3XuIJNeHDm");
            var response = await client.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();
            

            /*Console.WriteLine(responseBody);*/
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();
            var currentDate = DateTime.Now;
            Console.WriteLine($"{Environment.NewLine}Hello, {name}, what would you like to check out?");
            Console.Write($"{Environment.NewLine}You can search for books by typing 'book' or for chapters by typing 'chapter' or press 'ESC' to quit.");
            Console.ReadKey(true);

            
        }
    }
}
