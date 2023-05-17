namespace OnlineStoreOrderingSystem;

public interface IPrinter
{
    void PrintAvailableItems(List<Item> availableItems, decimal orderTotal);
}