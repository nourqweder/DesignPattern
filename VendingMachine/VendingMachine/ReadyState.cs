namespace VendingMachine;
// Define the Concrete State classes
// This class represents the state of the vending machine when it is ready to accept money
// but hasn't received any yet.
// 
public class ReadyState : IVendingMachineState
{
    private readonly VendingMachine _vendingMachine;
    //In the ReadyState class, the constructor takes a VendingMachine instance
    //as a parameter, allowing the state object to access the vending machine's properties
    //and change its state if needed.
    public ReadyState(VendingMachine vendingMachine)
    {
        this._vendingMachine = vendingMachine;
    }

    public void InsertCoin(decimal amount)
    {
        Console.WriteLine($"Accepted {amount:C}");
        _vendingMachine.CurrentBalance += amount;
        _vendingMachine.CurrentState = _vendingMachine.HasMoneyState;
    }

    public bool SelectItem(Item selectedItem)
    {
        Console.WriteLine("Please insert money first.");
        return false;
    }
}