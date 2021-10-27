using System;
using System.Collections.Generic;
// The below will enable HTTPClient
using System.Net.Http;
//Using Newtonsoft.Json to convert json to C# objects.
using Newtonsoft.Json.Linq;

namespace LOTRApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, What is your name?");
            var inputName = Console.ReadLine();
            Console.WriteLine($"{Environment.NewLine}Hi, {inputName}, what would you like to check out?");

            bool quitFlag = false;

            Console.WriteLine($"{Environment.NewLine}Please use the following commands for your enquiries.");
            Console.WriteLine($"{Environment.NewLine} - To list all books, type 'books'");
            Console.WriteLine($"{Environment.NewLine} - To search for a specific book, type book and then the 'id number' of the book");
            Console.WriteLine($"{Environment.NewLine} - To list all chapters in a book, type the 'chapter' and then the 'id number' of the book");
            Console.WriteLine($"{Environment.NewLine} - To list all movies, type 'movies'");
            Console.WriteLine($"{Environment.NewLine} - Or type 'q' to quit.");

            while (!quitFlag)
            {
                string userChoice = Console.ReadLine();

                if (userChoice == "q")
                {
                    Console.WriteLine("Good Bye");
                    quitFlag = true;
                }
                else if (userChoice == "books")
                {
                    GetBooks();
                }
                else if (userChoice == "book")
                {
                    Console.WriteLine($"{Environment.NewLine} - Please enter book id");
                    string bookid = Console.ReadLine();
                    GetOneBook(bookid);
                }
                else if (userChoice == "chapter")
                {
                    Console.WriteLine($"{Environment.NewLine} - Please enter book id");
                    string bookid = Console.ReadLine();
                    GetBookChapters(bookid);
                }
                else if (userChoice == "movies")
                {
                    GetMovies();
                }
            }
        }
        public static async void GetBooks()  //async method which will get all books
        {
            string baseUrl = "https://the-one-api.dev/v2/book/";  //Define base Url

            sendParsePrintRequest(baseUrl);
        }
        public static async void GetOneBook(string id)
        {
            string baseUrl = $"https://the-one-api.dev/v2/book/{id}/";

            sendParsePrintRequest(baseUrl);
        }
        public static async void GetBookChapters(string id)
        {
            string baseUrl = $"https://the-one-api.dev/v2/book/{id}/chapter";

            sendParsePrintRequest(baseUrl);
        }
        public static async void GetMovies()
        {
            string baseUrl = $"https://the-one-api.dev/v2/movie";

            sendParsePrintRequest(baseUrl);
        }
        public static async void sendParsePrintRequest(string baseUrl)
        {
            try { 
                using (HttpClient client = new HttpClient()) //instantiate a new request object
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer _7O4nscQGh3XuIJNeHDm"); // set bearer token to authorize my request
                    //client.DefaultRequestHeaders.Add("Authorization", $"Bearer jz1Z7ttrFJQZCXJgCz66"); // set bearer token to authorize my request
                    //client.DefaultRequestHeaders.Add("Authorization", $"Bearer 0WszKxgoMZdNateYxcLW"); // set bearer token to authorize my request

                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))  // sending request to API
                    {
                        //res.Headers.Add("Authorization", $"Bearer _7O4nscQGh3XuIJNeHDm");  
                        using (HttpContent content = res.Content) // get content out of the response
                        {
                            string data = await content.ReadAsStringAsync();    //read data in Json

                             if (data != null)
                            {
                                var dataObj = JObject.Parse(data);      //parse Json for readability
                                Console.WriteLine(dataObj["docs"]);
                                Console.WriteLine("Type 'book', 'books', 'chapter', 'movies' or press 'q' if you want to quit");
                            }
                            else
                            {
                                Console.WriteLine("Data is null!");
                            }
                        }
                    }
                }
            } catch(Exception exception) {
                Console.WriteLine(exception);
            }
        }
    }
}
