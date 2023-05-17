namespace OnlineStoreOrderingSystem;

public class InventoryManager : IInventoryManager
{
    private readonly List<Item> _inventory;

    public InventoryManager(List<Item> inventory)
    {
        _inventory = inventory;
    }

    public bool CheckAvailability(string itemId, int quantity)
    {
        var item = _inventory.FirstOrDefault(i => i.Id == itemId);

        if (item == null)
        {
            Console.WriteLine("Item does not exist in the inventory.");
            return false;
        }

        if (quantity <= item.AvailableQuantity)
        {
            return true;
        }

        Console.WriteLine("Item is not available in the requested quantity.");
        return false;
    }

    public void UpdateInventory(string itemId, int quantity)
    {
        var item = _inventory.FirstOrDefault(i => i.Id == itemId);

        if (item != null)
        {
            item.AvailableQuantity -= quantity;
        }
    }

    public List<Item> GetAvailableItems()
    {
        return _inventory;
    }
}

public class Item
{
    public Item(string id, string name, decimal price, int availableQuantity)
    {
        Id = id;
        Name = name;
        Price = price;
        AvailableQuantity = availableQuantity;
        Quantity = 0; // Initialize the quantity to 0
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int AvailableQuantity { get; set; }
    public int Quantity { get; set; }
}