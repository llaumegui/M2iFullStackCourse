namespace Demo01.Classes.BankAccount;

public class LiveAccount : BankAccount
{
    public LiveAccount(Client client) : base(client) { }
    
    public override string ToString() => "Compte Courant";
}