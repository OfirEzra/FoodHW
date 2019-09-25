using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FoodConsole
{
    class Program
    {
        private const string URL = "http://localhost:49839/api/foods";
        public class Food
        {
            public string Name { get; set; }
            public string Ingridients { get; set; }
            public int Calories { get; set; }
            public int Grade { get; set; }
        }
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                List<Food> dataObjects = response.Content.ReadAsAsync<List<Food>>().Result;
                for(int i = 0; i < dataObjects.Count(); i++)
                {
                    Console.WriteLine(dataObjects.ElementAt(i).Name);
                    Console.WriteLine(dataObjects.ElementAt(i).Ingridients);
                    Console.WriteLine(dataObjects.ElementAt(i).Calories);
                    Console.WriteLine(dataObjects.ElementAt(i).Grade);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            client.Dispose();
        }
    }
}
