namespace Exercise02.Classes;

public class Display
{
    private string MainMenu()
    {
        ShowTitle("Menu Principal");
        
        Console.WriteLine("1. Ajouter un client");
        Console.WriteLine("2. Afficher la liste des clients");
        Console.WriteLine("3. Afficher les réservations d'un client");
        Console.WriteLine("4. Ajouter une réservation");
        Console.WriteLine("5. Annuler une réservation");
        Console.WriteLine("6. Afficher la liste des réservations");
        Console.WriteLine("0. Quitter");

        Console.Write("Votre choix: ");
        return Console.ReadLine();
    }

    public void Start()
    {
        AppController app = new AppController(this);

        app.CreateNewHotel();
        while (true)
        {
            string choice = MainMenu();
            switch (choice)
            {
                case "1":
                    app.AddClient();
                    break;
                case "2":
                    app.ShowClientList();
                    break;
                case "3":
                    app.ShowClientBookings();
                    break;
                case "4":
                    app.AddBooking();
                    break;
                case "5":
                    app.CancelBooking();
                    break;
                case "6":
                    app.ShowBookingsList();
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
    
    public void ShowTitle(string text) => Console.WriteLine($"=== {text} ===\n");
}