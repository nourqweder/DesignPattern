namespace OnlineStoreOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the inventory
            var inventory = new List<Item>
            {
                new Item("item1", "Item 1", 10.0m, 10),
                new Item("item2", "Item 2", 15.0m, 20),
                new Item("item3", "Item 3", 20.0m, 5)
            };

            // Create the dependencies
            var inventoryManager = new InventoryManager(inventory);
            var itemPrices = new Dictionary<string, decimal>
            {
                { "item1", 10.0m },
                { "item2", 15.0m },
                { "item3", 20.0m }
            };
            var orderCalculator = new OrderCalculator(itemPrices);
            var printer = new ConsolePrinter();

            // Create the order facade
            var orderFacade = new OrderFacade(inventoryManager, orderCalculator, printer);

            // Print the available items

            printer.PrintAvailableItems(inventoryManager.GetAvailableItems(), 0);

            // orderFacade.PrintAvailableItems();

            Console.WriteLine("Welcome to the Online Store Ordering System!");
            while (true)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Place an order");
                Console.WriteLine("2. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter item ID: ");
                    var itemId = Console.ReadLine();

                    Console.Write("Enter quantity: ");
                    var quantityInput = Console.ReadLine();
                    if (!int.TryParse(quantityInput, out var quantity))
                    {
                        Console.WriteLine("Invalid quantity. Please try again.");
                        continue;
                    }

                    Console.Write("Enter shipping address: ");
                    var shippingAddress = Console.ReadLine();

                    // Place the order
                    orderFacade.PlaceOrder(itemId, quantity, shippingAddress);
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Thank you for using the Online Store Ordering System. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                Console.WriteLine();
            }
        }
    }
}
