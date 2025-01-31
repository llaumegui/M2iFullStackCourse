/*using Exercices.Classes;

internal static class IHM
{
    private static void AfficherMenu()
    {
        Console.WriteLine("1 - Afficher tous les clients");
        Console.WriteLine("2 - Créer un client");
        Console.WriteLine("3 - Modifier un client");
        Console.WriteLine("4 - Supprimer un client");
        Console.WriteLine("5 - Afficher les détails d'un client");
        Console.WriteLine("6 - Ajouter une commande");
        Console.WriteLine("7 - Modifier une commande");
        Console.WriteLine("8 - Supprimer une commande");
        Console.WriteLine("0 - Quitter");
    }

    private static void ShowClients()
    {
        ClientCommandOperations.GetClients().ForEach(client => Console.WriteLine(client));
    }
    private static void CreateClient() { }
    private static void ModifyClient() { }
    private static void DeleteClient() { }
    private static void ShowDetailClient() { }
    private static void AddCommand() { }
    private static void ModifyCommand() { }
    private static void DeleteCommand() { }

    public static void Start()
    {
        while (true)
        {
            AfficherMenu();
            string choix = Console.ReadLine()!;

            switch (choix)
            {
                case "1":
                    ShowClients();
                    break;
                case "2":
                    CreateClient();
                    break;
                case "3":
                    ModifyClient();
                    break;
                case "4":
                    DeleteClient();
                    break;
                case "5":
                    ShowDetailClient();
                    break;
                case "6":
                    AddCommand();
                    break;
                case "7":
                    ModifyCommand();
                    break;
                case "8":
                    DeleteCommand();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Erreur de saisie");
                    break;
            }
        }
    }
}*/