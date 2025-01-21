namespace Demo01.Classes.BankAccount;

public class Client
{
    private string _id;
    private string _telephoneNumber;
    private List<BankAccount> _bankAccounts;
    private static long _idGenerator;
    
    public string Name { get; }
    public string Id => _id;
    public string TelephoneNumber => _telephoneNumber;
    public List<BankAccount> BankAccounts => _bankAccounts;
    public List<string> BankAccountNames
    {
        get
        {
            List<string> names = new List<string>();
            foreach (BankAccount account in _bankAccounts)
                names.Add(account.ToString());
            return names;
        }
    }
        

    public Client(string name = "default name")
    {
        Random rnd = new Random();

        Name = name;
        _telephoneNumber =
            $"+33 {rnd.Next(6, 8)} {rnd.Next(0, 100).ToString("00")} {rnd.Next(0, 10).ToString("00")} {rnd.Next(0, 10).ToString("00")} {rnd.Next(0, 100).ToString("00")}";
        _id = _idGenerator++.ToString("N8");
        _bankAccounts = new List<BankAccount>();
    }

    public string RegisterNewAccount(BankAccount bankAccount)
    {
        foreach (BankAccount ba in _bankAccounts)
            if (bankAccount.GetType().Name == ba.GetType().Name)
                return $"Compte déjà existant";
        _bankAccounts.Add(bankAccount);
        return $"{bankAccount} créé avec succès !";
    }
        
}