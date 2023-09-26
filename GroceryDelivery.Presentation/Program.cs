using GroceryDelivery.Domain.Configurations;

namespace GroceryDelivery.Presentation;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        File.WriteAllText(DataPath.DriverDb, "salomat");
    }
}