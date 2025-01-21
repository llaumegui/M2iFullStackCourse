namespace Demo01.Classes.BankAccount;

public class PaidAccount : BankAccount
{
    public PaidAccount(Client client) : base(client) { }
    public override string ToString() => "Compte Payant";
}