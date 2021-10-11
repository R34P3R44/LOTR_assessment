
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
            Console.WriteLine($"{Environment.NewLine} - To list all chapters in a book, type the 'chapters' and then the 'id number' of the book");
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
            }
        }
        //async method which will get all books
        public static async void GetBooks()
        {
            //Define base Url
            string baseUrl = "https://the-one-api.dev/v2/book/";
            //try and catch block will will catch any exeptions
            try
            {
                //Defining a Http client
                using (HttpClient client = new HttpClient())
                {
                    //Initiating the Get Request with await keyword so the using statement will be executed in order.
                    //Httprespinsemessage contains status code and data from response.
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        res.Headers.Add("Authorization", $"Bearer _7O4nscQGh3XuIJNeHDm");
                        //Getting content from response and convert it to a C# object
                        using (HttpContent content = res.Content)
                        {
                            //Assigning the content to data variable by converting it to string with await keyword.
                            var data = await content.ReadAsStringAsync();

                            //Adding if statement to check data isnt null then return log convert whihc was convreted by newtonsoft.
                            if (data != null)
                            {
                                var dataObj = JObject.Parse(data);
                                //Logging data to console
                                Console.WriteLine(dataObj["docs"]);
                                Console.WriteLine("Type 'book', 'books', 'chapter' or press 'q' if you want to quit");
                            }
                            else
                            {
                                Console.WriteLine("NO Content---------");
                            }
                        }
                    }
                }
            } catch(Exception exception)
            {
                Console.WriteLine("Exception Hit----------");
                Console.WriteLine(exception);
            }
        }
        public static async void GetOneBook(string id)
        {
            string baseURL = $"https://the-one-api.dev/v2/book/{id}/";
            try { 
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        res.Headers.Add("Authorization", $"Bearer _7O4nscQGh3XuIJNeHDm");
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                var dataObj = JObject.Parse(data);
                                Console.WriteLine(dataObj["docs"]);
                                Console.WriteLine("Type 'book', 'books', 'chapter' or press 'q' if you want to quit");
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
        public static async void GetBookChapters(string id)
        {

            string baseURL = $"https://the-one-api.dev/v2/book/{id}/chapter";

            try { 

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        res.Headers.Add("Authorization", $"Bearer _7O4nscQGh3XuIJNeHDm");
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();

                             if (data != null)
                            {
                                var dataObj = JObject.Parse(data);
                                Console.WriteLine(dataObj["docs"]);
                                Console.WriteLine("Type 'book', 'books', 'chapter' or press 'q' if you want to quit");
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