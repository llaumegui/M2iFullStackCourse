/*
 static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Client client = new Client("Théo Lemoche");

        Menu mainMenu = new Menu("Menu Principal",
            new Dictionary<string, ConditionValue>()
            {
                { "1", new ConditionValue("Lister les comptes bancaires", true) },
                { "2", new ConditionValue("Créer un compte bancaire") },
                { "3", new ConditionValue("Effectuer un dépôt", true) },
                { "4", new ConditionValue("Effectuer un retrait", true) },
                { "5", new ConditionValue("Afficher les opérations et le solde", true) },
                { "0", new ConditionValue("Quitter") }
            });
        Menu createAccountMenu = new Menu("Création de compte",
            new Dictionary<string, ConditionValue>()
            {
                { "1", new ConditionValue("Créer un compte courant") },
                { "2", new ConditionValue("Créer un compte épargne") },
                { "3", new ConditionValue("Créer un compte payant") },
                { "0", new ConditionValue("Annuler la création du compte") }
            });

        string menuKey = "";
        Menu tempMenu;
        bool condition;
        while (true)
        {
            while (true)
            {
                Console.Clear();
                condition = client.BankAccounts.Count > 0;
                // dégueu
                Console.WriteLine($"=== {mainMenu.Title} ===");
                foreach (KeyValuePair<string, ConditionValue> kvp in mainMenu.MenuItems)
                {
                    if (kvp.Value.Condition == condition || !kvp.Value.Condition)
                        Console.ResetColor();
                    else
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{kvp.Key}. {kvp.Value}");
                }

                Console.Write("Votre choix: ");
                if (mainMenu.TryKey(Console.ReadLine(), client.BankAccounts.Count > 0, out menuKey))
                    break;
            }
            Console.Clear();

            if (menuKey == "0")
                break;

            switch (menuKey)
            {
                case "1":
                    foreach (BankAccount account in client.BankAccounts)
                        Console.WriteLine(account.ShowBalance());
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

                    Console.Clear();

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
                        Console.WriteLine($"{client.Name} - {selectedAccount.ShowBalance()}:");
                        for (int i = selectedAccount.Operations.Count-1;i>=0;i--)
                            Console.WriteLine(selectedAccount.Operations[i]);
                    }

                    break;
            }

            Console.Write("Appuyez sur Entrée pour continuer");
            Console.ReadLine();
        }
    }
    */

