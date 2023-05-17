namespace VendingMachine
{
    //By using the State pattern and defining different concrete state classes
    //like ReadyState, the vending machine can dynamically change its behavior
    //based on its current state, providing the necessary actions and
    //preventing invalid operations depending on the context.
    public class HasMoneyState : IVendingMachineState
    {
        private readonly VendingMachine _vendingMachine;

        public HasMoneyState(VendingMachine vendingMachine)
        {
            this._vendingMachine = vendingMachine;
        }

        public void InsertCoin(decimal amount)
        {
            Console.WriteLine($"Accepted {amount:C}");
            _vendingMachine.CurrentBalance += amount;
        }

        public bool SelectItem(Item selectedItem)
        {
            if (selectedItem.Price > _vendingMachine.CurrentBalance || selectedItem.AvailableQuantity <= 0)
            {
                Console.WriteLine($"Out of stock or not enough money for {selectedItem.Name}");
                return false;
            }

            Console.WriteLine($"Dispensing {selectedItem.Name}...");
            selectedItem.AvailableQuantity--;
            _vendingMachine.CurrentBalance -= selectedItem.Price;
            _vendingMachine.CurrentState = _vendingMachine.ReadyState;
            return true;
        }
    }
}