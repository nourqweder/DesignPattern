namespace OnlineStoreOrderingSystem;

public interface IInventoryManager
{
    bool CheckAvailability(string itemId, int quantity);
    void UpdateInventory(string itemId, int quantity);
    List<Item> GetAvailableItems();
}