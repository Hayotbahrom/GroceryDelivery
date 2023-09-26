using GroceryDelivery.Domain.Configurations;

namespace GroceryDelivery.Presentation;

public class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        UI uI = new UI();
        await uI.StartAsync();
    }
}