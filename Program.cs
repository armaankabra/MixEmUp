using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MixEmUp.Model;

namespace MixEmUp
{
    public class Program
    {
        public static Game[] games { get; set; }
        public static int maxcategories = 4;
        public static void Main(string[] args)
        {
            games = new Game[9999];
            Task cleartask = ClearGames();
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static async Task<int> ClearGames()
        {
            while (true)
            {
                int gameindex = 0;
                while (gameindex < games.Length)
                {
                    if (games[gameindex] != null)
                    {
                        if (DateTime.Now.Subtract(games[gameindex].gamestarttime).TotalMinutes > 30)
                        {
                            games[gameindex] = null;
                        }
                    }

                    gameindex++;
                }
                await Task.Delay(30 * 60 * 1000);
                
            }
        }
    }
}
