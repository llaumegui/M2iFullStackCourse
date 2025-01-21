Console.WriteLine("--- QCM ---\n");
Console.WriteLine("Quelle est l'instruction qui permet de sortir d'une boucle en C#?\n" +
                  "     a) quit\n" +
                  "     b) continue\n" +
                  "     c) break\n" +
                  "     d) exit");
bool end = false;
do
{
    Console.Write("Entrer votre réponse: ");
    string response = Console.ReadLine()!;
    if (response == "c")
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Bravo, c'est la bonne réponse! ");
        end = true;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Mauvaise réponse!");
        Console.ResetColor();
        do
        {
            Console.Write("Nouvel essai ? (oui/non): ");
            response = Console.ReadLine()!.ToLower();
        } while (response != "oui" && response != "non");
        if (response != "oui")
            end = true;
    }
} while (!end);