namespace Demo01.Classes.BankAccount;

public class SavingsAccount : BankAccount
{
    public SavingsAccount(Client client) : base(client) { }
    
    public override string ToString() => "Compte Épargne";
}