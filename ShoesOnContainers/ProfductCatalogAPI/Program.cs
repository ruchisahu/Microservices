using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProfductCatalogAPI.Data;

namespace ProfductCatalogAPI
{
    public class Program
    {
        public static void Main(string[] args)

        {

            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())      // setting up docker destroy docer andclean memory if use in a using loop.

            {

                var services = scope.ServiceProvider;  //docker providing alll the provider one iscatalogcontext

                var context =

                    services.GetRequiredService<CatalogContext>();

                CatalogSeed.SeedAsync(context).Wait();

            }

            host.Run();



        }



        public static IWebHost BuildWebHost(string[] args) =>

            WebHost.CreateDefaultBuilder(args)

                .UseStartup<Startup>()

                .Build();

    }

}