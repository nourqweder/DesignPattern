namespace OnlineStoreOrderingSystem;

public class OrderCalculator : IOrderCalculator
{
    private readonly Dictionary<string, decimal> _itemPrices;

    public OrderCalculator(Dictionary<string, decimal> itemPrices)
    {
        _itemPrices = itemPrices;
    }

    public decimal GetOrderTotal(string itemId, int quantity)
    {
        if (!_itemPrices.ContainsKey(itemId)) throw new ArgumentException("Item price not found for the given itemId.");
        var itemPrice = _itemPrices[itemId];
        return itemPrice * quantity;

    }
}