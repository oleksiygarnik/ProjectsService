using Agile.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Agile.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var menu = new ConsoleMenu(client);
            await menu.Run();

            Console.ReadKey();
        }
    }
}
