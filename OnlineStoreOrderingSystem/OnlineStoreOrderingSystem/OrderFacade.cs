namespace OnlineStoreOrderingSystem;

/// <summary>
/// Facade Design Pattern:creation 
/// The OrderFacade class serves as a facade that provides a simplified interface for placing an order.
/// It encapsulates the interaction with the complex subsystem components, such as the InventoryManager,
/// OrderCalculator, and Printer, on behalf of the client.
/// 
/// Benefits of Facade Design Pattern:
/// 1. Simplifies the client's interaction with a complex subsystem by providing a unified high-level interface.
/// 2. Hides the complexities of the subsystem and provides a simplified view, improving code readability and maintainability.
/// 3. Decouples the client from the detailed implementation of the subsystem, allowing changes in the subsystem to be
///    transparent to the client as long as the facade's interface remains stable.
/// 
/// In this code, the OrderFacade class provides a single method, PlaceOrder, which abstracts the process of placing an order.
/// It coordinates with the IInventoryManager to check item availability, the IOrderCalculator to calculate the order total,
/// and the IPrinter to print the available items and order total. The actual implementations of these components are injected
/// through the constructor, allowing flexibility and easy substitution of different implementations.
/// The client only needs to interact with the OrderFacade, which shields the client from the complexities of the subsystem.
/// </summary>
public class OrderFacade
{
    private readonly IInventoryManager _inventoryManager;
    private readonly IOrderCalculator _orderCalculator;
    private readonly IPrinter _printer;

    public OrderFacade(IInventoryManager inventoryManager, IOrderCalculator orderCalculator, IPrinter printer)
    {
        _inventoryManager = inventoryManager;
        _orderCalculator = orderCalculator;
        _printer = printer;
    }

    public bool PlaceOrder(string itemId, int quantity, string shippingAddress)
    {
        if (!_inventoryManager.CheckAvailability(itemId, quantity))
        {
            Console.WriteLine("Item is not available in the requested quantity.");
            return false;
        }

        var orderTotal = _orderCalculator.GetOrderTotal(itemId, quantity);
        _inventoryManager.UpdateInventory(itemId, quantity);
        _printer.PrintAvailableItems(_inventoryManager.GetAvailableItems(), orderTotal);

        return true;
    }
}