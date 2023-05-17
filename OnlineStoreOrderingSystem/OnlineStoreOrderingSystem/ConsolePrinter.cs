namespace OnlineStoreOrderingSystem;

public class ConsolePrinter : IPrinter
{
    public void PrintAvailableItems(List<Item> availableItems, decimal orderTotal)
    {
        Console.WriteLine("Available Items:");
        Console.WriteLine("----------------");

        foreach (var item in availableItems)
        {
            Console.WriteLine($"ID: {item.Id}\tName: {item.Name}\tPrice: ${item.Price}\tQuantity: {item.AvailableQuantity}");
        }

        Console.WriteLine($"Order Total: ${orderTotal}");
    }
}