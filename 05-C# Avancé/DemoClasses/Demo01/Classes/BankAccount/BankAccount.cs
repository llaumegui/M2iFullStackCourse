using System.Transactions;

namespace Demo01.Classes.BankAccount;

public abstract class BankAccount
{
    protected double _balance = 0;
    private Client _client;
    private List<Operation> _operations = new List<Operation>();
    public List<Operation> Operations => _operations;

    public BankAccount(Client client) { _client = client; }

    public bool AddOperation(Operation operation)
    {
        if(operation.Type == OperationType.Withdraw && operation.Amount>_balance)
            return false;
        
        _operations.Add(operation);
        
        _balance += operation.Type == OperationType.Deposit ? operation.Amount:-operation.Amount;
        
        return true;
    }
    
    public string ShowBalance()=>$"{this} | Balance: {_balance:N2}€";

    public string PrintOperations()
    {
        string msg = "";
        foreach (Operation operation in _operations)
            msg += $"{operation.ToString()}\n";
        return msg;
    }
}