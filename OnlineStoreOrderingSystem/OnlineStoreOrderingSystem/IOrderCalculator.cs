namespace OnlineStoreOrderingSystem;

public interface IOrderCalculator
{
    decimal GetOrderTotal(string itemId, int quantity);
}