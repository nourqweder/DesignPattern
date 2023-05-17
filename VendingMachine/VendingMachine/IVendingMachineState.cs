namespace VendingMachine;
// Define the State interface
public interface IVendingMachineState
{
    bool SelectItem(Item selectedItem);
    void InsertCoin(decimal amount);
}