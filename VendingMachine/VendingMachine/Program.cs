namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var vendingMachine = new VendingMachine();
            // Create item objects
            var item1 = new Item("Soda", 1.5m, 10);
            var item2 = new Item("Chips", 1.0m, 20);

            // Add items to the vending machine

            vendingMachine.AddItem(item1);
            vendingMachine.AddItem(item2);
            var isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Display available items");
                Console.WriteLine("2. Insert money");
                Console.WriteLine("3. Select item");
                Console.WriteLine("4. Check current balance");
                Console.WriteLine("5. Exit");

                int input;
                while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 5)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Available items:");
                        foreach (var item in vendingMachine.GetAvailableItems())
                        {
                            Console.WriteLine($"{item.Name} - {item.Price:C}");
                        }
                        break;

                    case 2:
                        Console.Write("Enter the amount you want to insert: ");
                        decimal amount;
                        while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                        {
                            Console.WriteLine("Invalid input. Please enter a positive number.");
                        }
                        vendingMachine.InsertMoney(amount);
                        Console.WriteLine($"Current balance: {vendingMachine.CurrentBalance:C}");
                        break;

                    case 3:
                        Console.WriteLine("Please select an item:");
                        for (var i = 0; i < vendingMachine.GetAvailableItems().Count; i++)
                        {
                            var item = vendingMachine.GetAvailableItems()[i];
                            Console.WriteLine($"{i + 1}. {item.Name} - {item.Price:C}");
                        }

                        int selection;
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out selection) && selection >= 1 && selection <= vendingMachine.GetAvailableItems().Count)
                            {
                                var selectedItem = vendingMachine.GetAvailableItems()[selection - 1];
                                Console.WriteLine(vendingMachine.SelectItem(selectedItem)
                                    ? $"You have selected {selectedItem.Name}."
                                    : "Item is out of stock or you don't have enough money.");
                                break;
                            }

                            Console.WriteLine($"Invalid input. Please enter a number between 1 and {vendingMachine.GetAvailableItems().Count}.");
                        }
                        break;

                    case 4:
                        Console.WriteLine($"Current balance: {vendingMachine.CurrentBalance:C}");
                        break;

                    case 5:
                        isRunning = false;
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Thank you for using the vending machine!");
        }
    }
}
