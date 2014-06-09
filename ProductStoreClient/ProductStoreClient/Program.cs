using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProductStoreClient
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }

    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Press A to view or delete\nPress B to add");
                ConsoleKey input = Console.ReadKey().Key;
                Console.Clear();
                switch (input)
                {
                    case ConsoleKey.A:
                        RunAsyncRead().Wait();
                        break;
                    case ConsoleKey.B:
                        RunAsyncPost().Wait();
                        break;
                }
                Console.Clear();
            }
            //Console.ReadKey();
        }

        static async Task RunAsyncPost()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:40953/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Product p = new Product();
                while (true)
                {
                    bool hasError = false;
                    Console.WriteLine("write name");
                    string name = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("write price");
                    double price = 0;
                    if (!double.TryParse(Console.ReadLine(), out price))
                    {
                        hasError = true;
                    }
                    Console.Clear();

                    Console.WriteLine("write category");
                    string category = Console.ReadLine();
                    Console.Clear();

                    if (!hasError)
                    {
                        p = new Product()
                        {
                            Category = category,
                            Name = name,
                            Price = price
                        };
                        break;
                    }
                    else
                    {
                        Console.WriteLine("u have errors, press any key to try again");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }

                HttpResponseMessage response = await client.PostAsJsonAsync("api/products", p);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("succefully added");
                    Console.ReadKey();
                }
            }
        }

        static async Task RunAsyncRead()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:40953/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/products");
                if (response.IsSuccessStatusCode)
                {
                    List<Product> listProduct = await response.Content.ReadAsAsync<List<Product>>();
                    for (int i = 0; i < listProduct.Count; i++)
                    {
                        Console.WriteLine(1 + i + " :{0}\t${1}\t{2}", listProduct[i].Name, listProduct[i].Price, listProduct[i].Category);

                    }
                    Console.WriteLine("\nPress ID number to delete or any other key to go back");

                    int key = Console.ReadKey().KeyChar - 48;
                    Console.Clear();
                    if (key > 0 && listProduct.Count >= key)
                    {
                        response = await client.DeleteAsync("api/products/" + listProduct[key - 1].Id);

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("succesfully deleted");
                        }
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}