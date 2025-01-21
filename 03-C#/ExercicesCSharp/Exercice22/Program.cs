using System.Drawing;

Console.WriteLine("--- Gestion des notes ---\n");
Console.WriteLine("Veuillez saisir 5 notes: ");
int i = 1;
float average = 0, min = 20, max = 0;
while (i <= 5)
{
    Console.Write($"     - Merci de saisir la note {i} (sur /20): ");
    float test = float.Parse(Console.ReadLine()!);
    min = test<min?test:min;
    max = test>max?test:max;
    average += test;
    i++;
}
average /= 5f;
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"La meilleure note est: {max:.##}/20");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"La moins bonne note est: {min:.##}/20");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine($"La moins bonne note est: {average:.##}/20");
