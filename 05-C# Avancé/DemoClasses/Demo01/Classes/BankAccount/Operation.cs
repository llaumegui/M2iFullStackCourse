namespace Demo01.Classes.BankAccount;

public class Operation
{
    private string _id;
    private double _amount;
    private static int _operationCount = 0;
    private OperationType _type;
    
    public OperationType Type => _type;
    public double Amount => _amount;

    public Operation(double amount, OperationType type)
    {
        _amount = amount;
        _type = type;
        _id = _operationCount++.ToString();
    }

    public override string ToString() => $"n°{_id} - {_type} | {(_type==OperationType.Deposit?"+":"-")}{_amount:N2}€";
}

public enum OperationType
{
    Deposit,
    Withdraw
}