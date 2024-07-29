using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var quote = new RonVSKanyeAPI(client);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("====================================================");
                Console.WriteLine($"Kanye: {quote.Kanye()}");
                Console.WriteLine();
                Console.WriteLine($"Ron Swanson: {quote.RonSwanson()}");
            }
        }
    }
}
