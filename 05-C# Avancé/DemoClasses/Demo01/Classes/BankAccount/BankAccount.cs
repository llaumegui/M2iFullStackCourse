using System.Transactions;

namespace Demo01.Classes.BankAccount;

public abstract class BankAccount
{
    private double _balance = 0;
    private Client _client;
    private List<Operation> _operations = new List<Operation>();
    public List<Operation> Operations => _operations;

    public BankAccount(Client client) { _client = client; }

    public override string ToString() => $"{GetType().Name}: | Balance: {_balance}€";

    public bool AddOperation(Operation operation)
    {
        if(operation.Type == OperationType.Withdraw && operation.Amount>_balance)
            return false;
        
        _operations.Add(operation);
        return true;
    }

    public string PrintOperations()
    {
        string msg = "";
        foreach (Operation operation in _operations)
            msg += $"{operation.ToString()}\n";
        return msg;
    }
}