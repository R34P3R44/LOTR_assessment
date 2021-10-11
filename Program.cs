using System.Net.Http;
using Newtonsoft.Json.Linq;









/*using System;
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

            var requestSpecBookChapter = new HttpRequestMessage(HttpMethod.Get, "https://the-one-api.dev/v2/book/{id}/chapter");
            requestSpecBookChapter.Headers.Add("Authorization", $"Bearer _7O4nscQGh3XuIJNeHDm");
            var responseSpecBookChapter = await client.SendAsync(requestSpecBookChapter);
            string responseBodySpecBookChapter = await responseSpecBookChapter.Content.ReadAsStringAsync();

            static void GetBookValues()
{
                string json = new HttpClient().DownloadString("https://the-one-api.dev/v2/book/");

                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);

                foreach (var item in items)
                {
                    Console.WriteLine("ID: " + item.id.ToUpper());
                    Console.WriteLine("Name: " + item.name.ToUpper());
                    Console.WriteLine("ChapterName: " + item.symbol.ToUpper());
                    Console.WriteLine("Book: " + item.rank.ToUpper());
                    //Console.WriteLine("Price (USD): " + item.price_usd.ToUpper());
                    Console.WriteLine("\n");
                }
        }



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
                    Console.WriteLine(responseBodySpecBookChapter);
                }
            }
        }
    }
}*/


