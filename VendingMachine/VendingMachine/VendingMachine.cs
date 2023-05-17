namespace VendingMachine
{
    public class VendingMachine
    {
        private List<Item> _items;
        public IReadOnlyList<Item> Items => _items;
        public decimal CurrentBalance { get; set; }
        public int Amount { get; set; }
        //CurrentState represents the current state of the vending machine. 
        public IVendingMachineState CurrentState { get; set; }
        public IVendingMachineState HasMoneyState { get; private set; }
        public IVendingMachineState ReadyState { get; private set; }

        public VendingMachine()
        {
            _items = new List<Item>();
            CurrentBalance = 0.0m;

            // Initialize states
            HasMoneyState = new HasMoneyState(this);
            ReadyState = new ReadyState(this);

            // Set initial state
            CurrentState = ReadyState;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public bool SelectItem(Item selectedItem)
        {
            if (selectedItem.AvailableQuantity <= 0)
            {
                Console.WriteLine("Item is out of stock.");
                return false;
            }

            if (selectedItem.Price > CurrentBalance)
            {
                Console.WriteLine("Please insert money first.");
                return false;
            }

            selectedItem.AvailableQuantity--;
            CurrentBalance -= selectedItem.Price;
            Console.WriteLine($"You have successfully purchased {selectedItem.Name}.");
            return true;
        }


        public void InsertMoney(decimal amount)
        {
            CurrentState.InsertCoin(amount);
        }

        public decimal GetCurrentBalance()
        {
            return CurrentBalance;
        }

        public List<Item> GetAvailableItems()
        {
            return _items.Where(item => item.AvailableQuantity > 0).ToList();
        }
    }

    public class Item
    {
        public string Name { get; }
        public decimal Price { get; }
        public int AvailableQuantity { get; set; }

        public Item(string name, decimal price, int availableQuantity)
        {
            Name = name;
            Price = price;
            AvailableQuantity = availableQuantity;
        }
    }

}
