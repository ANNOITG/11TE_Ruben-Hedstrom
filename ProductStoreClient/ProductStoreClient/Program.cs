﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProductStoreClient
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Press A to view, press B to add");
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

            Console.ReadKey();
        }

        static async Task RunAsyncPost()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:40953/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var gizmo = new Product() { Name = "Gizmo", Price = 100, Category = "Widget" };
                HttpResponseMessage response = await client.PostAsJsonAsync("api/products", gizmo);
                if (response.IsSuccessStatusCode)
                {
                    Uri gizmoUrl = response.Headers.Location;

                    // HTTP PUT
                    gizmo.Price = 80;   // Update price
                    response = await client.PutAsJsonAsync(gizmoUrl, gizmo);

                    // HTTP DELETE
                    response = await client.DeleteAsync(gizmoUrl);
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
                HttpResponseMessage response = await client.GetAsync("api/products/1");
                if (response.IsSuccessStatusCode)
                {
                    Product product = await response.Content.ReadAsAsync<Product>();
                    Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }

            }
        }
    }
}