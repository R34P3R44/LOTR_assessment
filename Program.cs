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

            var requestChapter = new HttpRequestMessage(HttpMethod.Get, "https://the-one-api.dev/v2/chapter/");
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
                Console.WriteLine($"{Environment.NewLine} - To list all books type 'book'");
                Console.WriteLine($"{Environment.NewLine} - To search for a specific book type 'book id'");
                Console.WriteLine($"{Environment.NewLine} - To list all chapters in a book type 'chapter name'");
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
