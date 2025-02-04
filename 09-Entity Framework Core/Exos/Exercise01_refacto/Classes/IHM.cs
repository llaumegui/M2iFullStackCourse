namespace Exercise01_refacto.Classes;

public class IHM
{
    private string MainMenu()
    {
        Console.WriteLine(
            "  ____\n |  _ \\ ___ _ __ ___  ___  __  __ __  _  __ _  __ _  ___ \n | |_) / _ \\ '__/ __|/ _ \\|  \\| ||  \\| |/ _` |/ _` |/ _ \\\n |  __/  __/ |  \\__ \\ (_) | |\\  || |\\  | (_| | (_| |  __/\n |_|   \\___|_|  |___/\\___/|_| \\_||_| \\_|\\__,_|\\__, |\\___|\n                                       \t      |___/");
        Console.WriteLine("1. Créer un personnage");
        Console.WriteLine("2. Mettre à jour un personnage");
        Console.WriteLine("3. Afficher tous les personnages");
        Console.WriteLine("4. Taper un personnage");
        Console.WriteLine("5. Afficher les personnages avec des PVs supérieur à la moyenne");
        Console.WriteLine("0. Quitter");

        Console.Write("Votre choix: ");
        return Console.ReadLine();
    }

    public void Start()
    {
        AppController app = new AppController(this);
        while (true)
        {
            string choice = MainMenu();
            switch (choice)
            {
                case "1":
                    app.CreateCharacter();
                    break;
                case "2":
                    app.UpdateCharacter();
                    break;
                case "3":
                    app.ShowCharacters();
                    break;
                case "4":
                    app.HitCharacter();
                    break;
                case "5":
                    app.ShowCharacters(ConditionFilter.HpOverAverage);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Une erreur est survenue");
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

    public string GetInput(string text = "")
    {
        Console.Write(text);
        return Console.ReadLine();
    }

    public void ShowOutput(string text) => Console.WriteLine(text);
}