Console.WriteLine("--- Gestion des notes avec menus ---\n");
string menu = "";
Console.Write("Insérer le nombre de contacts: ");
int max = int.Parse(Console.ReadLine()!);
string[] contacts = new string[max];
Console.Clear();
do
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--- Menu: ---");
    Console.ResetColor();
    Console.Write("1--- Saisir les contacts\n");
    if (contacts[0] == null)
        Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("2--- Afficher mes contacts\n");
    Console.ResetColor();
    Console.Write("0--- Quitter\n\n");
    Console.Write("Faites votre choix: ");
    menu = Console.ReadLine()!;
    
    if ((contacts[0] != null && menu != "0") || (contacts[0] == null && menu=="1"))
    {
        Console.Clear();
        switch (menu)
        {
            case "1":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--- Saisir les contacts: ---\n");
                Console.ResetColor();
                int count = 0;
                do
                {
                    Console.Write($"Nom et prénom du contact {count+1}: ");
                    contacts[count] = Console.ReadLine()!;
                    count++;

                } while (count < contacts.Length);
                break;
            case "2":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"--- Affichage des contacts: ---\n");
                Console.ResetColor();
                for(int i = 0; i < contacts.Length; i++)
                    Console.WriteLine($"Contact N°{i+1}: {contacts[i]}");
                
                Console.Write("Appuyez sur Entrée pour continuer");
                Console.ReadLine();
                break;
        }
    }
    Console.Clear();
}while(menu != "0");
