// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using UL.Abstractions.Interfaces;
using UL.Core.Extensions;
using UL.Core.Requests;
using UL.Services.Extensions;

internal class Program
{
    static void Main(string[] args)
    {
        // Setup serilog static logger
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateBootstrapLogger();

        try
        {
            Log.Information("Starting Account Service Web");

            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                    {
                        services.AddServices();
                    })
                .Build();

            var showMenu = true;

            while (showMenu)
            {
                showMenu = MainMenu(host.Services);
            }
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static bool MainMenu(IServiceProvider hostProvider)
    {
        using var serviceScope = hostProvider.CreateScope();
        var provider = serviceScope.ServiceProvider;

        Console.Clear();
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) FizzBuzz");
        Console.WriteLine("2) Factorial");
        Console.WriteLine("3) Exit");
        Console.Write("\r\nSelect an option: ");

        switch (Console.ReadLine())
        {
            case "1":
                HandleFizzBuzz(provider);
                return true;
            case "2":
                HandleFactorial(provider);
                return true;
            case "3":
                return false;
            default:
                return true;
        }
    }

    private static void HandleFizzBuzz(IServiceProvider provider)
    {
        try
        {
            var service = provider.GetRequiredService<IFizzBuzzService>();

            Console.Write("\n\n");
            Console.Write("Calculate fizzbuzz for a range:\n");
            Console.Write("--------------------------------------------");
            Console.Write("\n\n");

            Console.Write("Input the start : ");
            var startValue = Console.ReadLine();

            Console.Write("Input the end : ");
            var endString = Console.ReadLine();

            var request = new FizzBuzzRequest(startValue, endString);
            var result = service.GetFizzBuzzList(request);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.Write("\n\n");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    private static void HandleFactorial(IServiceProvider provider)
    {
        try
        {
            var service = provider.GetRequiredService<IFactorialService>();

            Console.Write("\n\n");
            Console.Write("Calculate the factorial of a given number:\n");
            Console.Write("--------------------------------------------");
            Console.Write("\n\n");

            Console.Write("Input the number : ");

            var result = Console.ReadLine();

            if (result.IsNumeric())
            {
                Console.WriteLine($"Factorial of {result} is {service.Calculate(Convert.ToInt32(result))}");
            }
            else
            {
                Console.WriteLine($"Value '{result}' is invalid. Please check and try again.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.Write("\n\n");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();

    }
}