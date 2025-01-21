Console.WriteLine("--- Trouvez le nombre mystère (entre 0 et 100) ---\n");
Random rnd = new Random();
int val = rnd.Next(101);
int test = -1, count = 0;
do
{
    Console.Write("Veuillez saisir un nombre: ");
    if (int.TryParse(Console.ReadLine(), out test))
    {
        if (test >= 0 && test <= 100)
        {
            count++;
            Console.ForegroundColor = ConsoleColor.Red;
            if (test !=val)
                Console.WriteLine("     Le nombre mystère est "+(test<val?"plus grand":"plus petit"));
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Le nombre choisi est trop "+(test<0?"petit.":"grand." + "pour jouer"));
            Console.ResetColor();
        }
    }
} while (test != val);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Bravo!!! Vous avez trouvé le nombre mystère "+(count ==1?"du premier coup!":$"en {count} coups!"));
