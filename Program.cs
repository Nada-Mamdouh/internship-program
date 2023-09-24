
// create hosting object and DI layer
using InternshipProgramTask.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using InternshipProgramTask.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;

using IHost host = CreateHostBuilder(args).Build();

// create a service scope
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;
// add entry point or call service methods
// more .....

try
{
    var appInstance = services.GetRequiredService<App>();
    appInstance.DoWork();
    appInstance.Run(args);
    
    
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// implementatinon of 'CreateHostBuilder' static method and create host object
IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        //enabling reading configuration from appsettings.json file
        .ConfigureAppConfiguration(app =>
             app.AddJsonFile("appsettings.json")
        )//enabling DI & adding services to container
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IDbClient<ProgramClass>, CosmosDbClient_ProgramClass>();
            services.AddSingleton<IProgramRepo, ProgramRepo>();
            services.AddSingleton<App>();
        });
}
Console.WriteLine("Hello, World!");
