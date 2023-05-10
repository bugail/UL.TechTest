// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UL.Abstractions.Interfaces;
using UL.Core.Extensions;
using UL.Services.Extensions;

internal class Program
{
    static void Main(string[] args)
    {
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

    private static bool MainMenu(IServiceProvider provider)
    {
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

    private static void HandleFizzBuzz(IServiceProvider hostProvider)
    {
        using var serviceScope = hostProvider.CreateScope();
        var provider = serviceScope.ServiceProvider;
        var service = provider.GetRequiredService<IFizzBuzzService>();

        var list = Enumerable.Range(1, 100).ToList();
        var result = service.GetFizzBuzzList(list);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    private static void HandleFactorial(IServiceProvider hostProvider)
    {
        try
        {
            using var serviceScope = hostProvider.CreateScope();
            var provider = serviceScope.ServiceProvider;
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

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();

    }
}