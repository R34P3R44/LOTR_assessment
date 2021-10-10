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

            var requestBook = new HttpRequestMessage(HttpMethod.Get, "https://the-one-api.dev/v2/book/");
            requestBook.Headers.Add("Authorization", $"Bearer _7O4nscQGh3XuIJNeHDm");
            var responseBook = await client.SendAsync(requestBook);
            string responseBodyBook = await responseBook.Content.ReadAsStringAsync();

            var requestChapter = new HttpRequestMessage(HttpMethod.Get, "https://the-one-api.dev/v2/book{name}/");
            requestChapter.Headers.Add("Authorization", $"Bearer _7O4nscQGh3XuIJNeHDm");
            var responseChapter = await client.SendAsync(requestChapter);
            string responseBodyChapter = await responseChapter.Content.ReadAsStringAsync();

            Console.WriteLine("Hi, What is your name?");
            var inputName = Console.ReadLine();
            Console.WriteLine($"{Environment.NewLine}Hi, {inputName}, what would you like to check out?");


            bool quitFlag = false;
            while (!quitFlag)
            {
                Console.WriteLine($"{Environment.NewLine}Please use the following commands for your enquiries.");
                Console.WriteLine($"{Environment.NewLine} - You can search for books by typing 'book'");
                Console.WriteLine($"{Environment.NewLine} - You can search for chapters by typing 'chapter'");
                Console.WriteLine($"{Environment.NewLine} - Or type 'q' to quit.");
                string userChoice = Console.ReadLine();

                if (userChoice == "q")
                {
                    quitFlag = true;
                }
                else if (userChoice == "book")
                {
                    Console.WriteLine(responseBodyBook);
                }
                else if (userChoice == "chapter")
                {
                    Console.WriteLine(responseBodyChapter);
                }
            }
        }
    }
}
