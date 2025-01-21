Console.WriteLine("--- Gestion des notes avec menus ---\n");
float max = 0, min = 20,total = 0;
int count = 0;
string menu = "";
do
{
    Console.Write("1--- Saisir les notes\n");
    if (count == 0)
        Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("2--- La plus grande note\n");
    Console.Write("3--- La plus petite note\n");
    Console.Write("4--- La moyenne des notes\n");
    Console.ResetColor();
    Console.Write("0--- Quitter\n\n");
    Console.Write("Faites votre choix: ");
    menu = Console.ReadLine()!;
    
    if ((count != 0 && menu != "0") || (count==0 && menu=="1"))
    {
        switch (menu)
        {
            case "1":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--- Saisir les notes (/20) ---\n(999 pour arrêter la saisie):");
                Console.ResetColor();
                float test = -1;
                do
                {
                    Console.Write($"Saisir la note {count+1}: ");
                    if(float.TryParse(Console.ReadLine(), out test))
                    {
                        if ((test > 20 || test < 0 ) && test != 999)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(test>20?"     La note saisie est supérieure à 20\n":"     La note saisie est inférieure à 0\n");
                            Console.ResetColor();
                            continue;
                        }
                        if(test != 999)
                        {
                            count++;
                            max = test>max?test:max;
                            min = test<min?test:min;
                            total += test;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("     ERREUR DE SAISIE\n");
                        Console.ResetColor();
                    }
                } while (test != 999f);
                break;
            case "2":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"La plus grande note est: {max:0.##}/20");
                Console.ResetColor();
                Console.Write("Appuyez sur Entrée pour continuer");
                Console.ReadLine();
                break;
            case "3":
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"La plus petite note est: {min:0.##}/20");
                Console.ResetColor();
                Console.Write("Appuyez sur Entrée pour continuer");
                Console.ReadLine();
                break;
            case "4":
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"La moyenne est de: {(total/count):0.##}/20");
                Console.ResetColor();
                Console.Write("Appuyez sur Entrée pour continuer");
                Console.ReadLine();
                break;
        }
    }
    Console.Clear();
}while(menu != "0");
