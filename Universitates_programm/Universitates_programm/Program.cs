using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
namespace Universitates_programm
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var WebKlients = new HttpClient();
            var atbilde = await WebKlients.GetAsync("http://universities.hipolabs.com/search?name=latvia");
            if (atbilde.IsSuccessStatusCode)
            {
                var AtbildesDati = await atbilde.Content.ReadAsStringAsync();
                dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(AtbildesDati);

                for (int i = 0; i < data.Count; i++)
                {
                    //string Uni = data[i].name;
                    Console.WriteLine(data[i].web_pages[0]);

                }
                Console.Read();
            }
        }

    }
}