Console.WriteLine("--- Fizzbuzz ---\n");
Console.Write("Entrer le nombre maximum à compter: ");
int max = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Je commence à compter: ");
int i = 1;
while (i <= max)
{
    if (i % 3 == 0 || i % 5 == 0)
    {
        if (i % 3 == 0)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Fizz");
            Console.ResetColor();
        }
        if (i % 5 == 0)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("buzz");
            Console.ResetColor();
        }
    }
    else 
        Console.Write(i.ToString());
    Console.Write("\n");
    i++;
}