using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParseLogFile.Repo;
using System;
using System.IO;

namespace ParseLogFile
{
    class Program
    {
        public static IConfigurationRoot configuration;
        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            try
            {
                // Start the actual workflow
                serviceCollection.BuildServiceProvider().GetService<FileParser>().Parse(args); //Async .Wait();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed!!! \r\n"+ ex.InnerException.Message??ex.Message);
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton(configuration);

            serviceCollection.AddSingleton<FileParser>();
            serviceCollection.AddEntityFrameworkSqlServer()
            .AddDbContext<LogContext>(options => options.UseSqlServer(configuration.GetConnectionString("DataMartConnection")));
        }
    }
}
