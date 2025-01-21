string[] names = new string[]
    { "Albert", "Herbert", "Gilbert", "Christophert", "Pomme de terre", "Mussolinux", "Benoix", "Benoisette" };
Console.WriteLine("--- Le grand tirage au sort ---\n");
string[] selected = new string[names.Length];
int nbrSelected = 0;
string menu = "";
Random rnd = new Random();
do
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--- Menu: ---");
    Console.ResetColor();
    if (nbrSelected >= names.Length)
        Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("1--- Faire un tirage\n");
    Console.ResetColor();
    if (nbrSelected == 0)
        Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("2--- Voir la liste des personnes tirées\n");
    Console.ResetColor();
    if (nbrSelected >= names.Length)
        Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("3--- Voir la liste des personnes restantes\n");
    Console.ResetColor();
    Console.Write("0--- Quitter\n\n");

    Console.Write("Faites votre choix: ");
    menu = Console.ReadLine()!;

    if (menu != "0")
    {
        Console.Clear();
        switch (menu)
        {
            case "1":
                if (nbrSelected >= names.Length - 1) break;
                int indexWinner = rnd.Next(0, names.Length - nbrSelected);
                selected[nbrSelected] = names[indexWinner];
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--- L'heureux Gagnant est: ---");
                Console.WriteLine($"--- {names[indexWinner]} ---");
                Console.WriteLine("--- Bravo: ---");
                Console.ResetColor();

                //update array
                if (indexWinner != names.Length - 1 - nbrSelected)
                {
                    names[indexWinner] = names[names.Length - 1 - nbrSelected];
                }

                nbrSelected++;
                Console.Write("Appuyez sur Entrée pour continuer");
                Console.ReadLine();
                break;
            case "2":
                if (nbrSelected == 0) break;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"--- Affichage des heureux gagnants: ---\n");
                Console.ResetColor();
                for (int i = 0; i < nbrSelected; i++)
                    Console.WriteLine($"{new string(' ',i*5)}{selected[i]}");

                Console.Write("Appuyez sur Entrée pour continuer");
                Console.ReadLine();
                break;
            case "3":
                if (nbrSelected == names.Length) break;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"--- Affichage des joueurs restants: ---\n");
                Console.ResetColor();
                int count = 0;
                for (int i = 0; i < names.Length; i++)
                {
                    if (Array.IndexOf(selected, names[i]) == -1)
                    {
                        Console.WriteLine($"{new string(' ',count*5)}{names[i]}");
                        count++;
                    }
                }

                Console.Write("Appuyez sur Entrée pour continuer");
                Console.ReadLine();
                break;
        }
    }
    Console.Clear();
} while (menu != "0");