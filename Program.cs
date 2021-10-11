
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
            Console.WriteLine("Hello World!");
            GetBook();
            GetOneBook(1);
            Console.ReadLine();
            Console.ReadKey();
        }



//async method which will get all books
        public static async void GetBook()
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
                        //Getting content from response and convert it to a C# object
                        using (HttpContent content = res.Content)
                        {
                            //Assigning the content to data variable by converting it to string with await keyword.
                            var data = await content.ReadAsStringAsync();

                            //Adding if statement to check data isnt null then return log convert whihc was convreted by newtonsoft.
                            if (data != null)
                            {
                                //Logging data to console
                                Console.WriteLine("data-----------{0}", data, JObject.Parse(data)["results"]);
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


        public static async void GetOneBook(int id)
        {
            //Define your base url
            string baseURL = $"https://the-one-api.dev/v2/book/{id}/";
            //Have your api call in try/catch block.
            try { 
                //Now we will have our using directives which would have a HttpClient 
                using (HttpClient client = new HttpClient())
                {
                    //Now get your response from the client from get request to baseurl.
                    //Use the await keyword since the get request is asynchronous, and want it run before next asychronous operation.
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        //Now we will retrieve content from our response, which would be HttpContent, retrieve from the response Content property.
                        using (HttpContent content = res.Content)
                        {
                            //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
                            string data = await content.ReadAsStringAsync();
                            //If the data is not null, parse the data to a C# object, then create a new instance of PokeItem.
                            if (data != null)
                            {
                                //Parse your data into a object.
                                var dataObj = JObject.Parse(data);
                                //Then create a new instance of PokeItem, and string interpolate your name property to your JSON object.
                                //Which will convert it to a string, since each property value is a instance of JToken.
                                LotrItem lotrItem = new LotrItem(name: $"{dataObj["name"]}");
                                //Log your pokeItem's name to the Console.
                                Console.WriteLine("Pokemon Name: {0}", lotrItem.Name);
                            }
                            else
                            {
                                //If data is null log it into console.
                                Console.WriteLine("Data is null!");
                            }
                        }
                    }
                }
                //Catch any exceptions and log it into the console.
            } catch(Exception exception) {
                Console.WriteLine(exception);
            }
        }
    }
}







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


