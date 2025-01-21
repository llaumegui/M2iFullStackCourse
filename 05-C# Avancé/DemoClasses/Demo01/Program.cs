using Demo01.Classes.BankAccount;
using Demo01.Classes.Menus;

namespace Demo01;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Client client = new Client("Théo Lemoche");

        Menu mainMenu = new Menu("Menu Principal",
            new Dictionary<string, string>()
            {
                { "1", "Lister les comptes bancaires" },
                { "2", "Créer un compte bancaire" },
                { "3", "Effectuer un dépôt" },
                { "4", "Effectuer un retrait" },
                { "5", "Afficher les opérations et le solde" },
                { "0", "Quitter" }
            });
        Menu createAccountMenu = new Menu("Création de compte",
            new Dictionary<string, string>()
            {
                { "1", "Créer un compte courant" },
                { "2", "Créer un compte épargne" },
                { "3", "Créer un compte payant" },
                { "0", "Annuler la création du compte" }
            });

        string menuKey = "";
        Menu tempMenu;
        while (true)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(mainMenu);
                Console.Write("Votre choix: ");
                if (mainMenu.TryKey(Console.ReadLine(), out menuKey))
                    break;
            }

            if (menuKey == "0")
                break;

            if (menuKey != "2" && client.BankAccounts.Count < 1)
            {
                menuKey = "-1";
                Console.WriteLine("Ce client ne possède aucun compte chez nous");
            }

            switch (menuKey)
            {
                case "1":
                    foreach (BankAccount account in client.BankAccounts)
                        Console.WriteLine(account);
                    break;
                case "2":
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(createAccountMenu);
                        Console.Write("Votre choix: ");
                        if (mainMenu.TryKey(Console.ReadLine(), out menuKey))
                            break;
                    }

                    if (menuKey != "0")
                    {
                        BankAccount account = menuKey switch
                        {
                            "1" => new LiveAccount(client),
                            "2" => new SavingsAccount(client),
                            "3" => new PaidAccount(client),
                        };
                        Console.WriteLine(client.RegisterNewAccount(account));
                    }
                    break;
                case "3":
                case "4":
                case "5":
                    BankAccount selectedAccount;
                    string tempKey = "";
                    if (client.BankAccounts.Count > 1)
                    {
                        tempMenu = new Menu("Sélectionner le compte", client.BankAccountNames);
                        tempKey = "-1";
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine(tempMenu);
                            Console.Write("Votre choix: ");
                            if (mainMenu.TryKey(Console.ReadLine(), out tempKey))
                                break;
                        }

                        int index = int.Parse(tempKey);
                        selectedAccount = client.BankAccounts[index - 1];
                    }
                    else
                        selectedAccount = client.BankAccounts[0];

                    if (menuKey != "5")
                    {
                        Console.Write("Saisissez le montant: ");
                        double amount = double.Parse(Console.ReadLine());
                        OperationType type = menuKey == "3" ? OperationType.Deposit : OperationType.Withdraw;
                        if (selectedAccount.AddOperation(new Operation(amount, type)))
                            Console.WriteLine("Opération réussie");
                        else
                            Console.WriteLine("Opération échouée");
                    }
                    else
                    {
                        foreach (Operation operation in selectedAccount.Operations)
                            Console.WriteLine(operation);
                    }

                    break;
            }

            Console.Write("Appuyez sur Entrée pour continuer");
            Console.ReadLine();
        }
    }
}