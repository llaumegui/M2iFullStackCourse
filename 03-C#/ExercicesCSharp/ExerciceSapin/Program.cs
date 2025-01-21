using System.Drawing;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("--- Très joli sapin ---\n");

Console.Write("Saisir la hauteur du sapin: ");
int height = Convert.ToInt32(Console.ReadLine()!);
Console.Write("Saisir la hauteur du tronc: ");
int trunc = Convert.ToInt32(Console.ReadLine()!);
Console.ForegroundColor = ConsoleColor.Yellow;
Random rnd = new Random();
for (int i = 1; i <= height; i++)
{
    string space = new string(' ', (height-i));
    Console.Write(space);
    if (i != 1)
    {
        for (int j = 1; j < 2 * i; j++)
            Console.Write(GetSymbol());
    }
    else
        Console.Write('✨');
    Console.Write(space+"\n");
} ;
Console.ForegroundColor = ConsoleColor.DarkRed;
string truncSpace = new string(' ', (height-2));
for (int i = 0; i < trunc; i++)
{
    Console.WriteLine(truncSpace+"| |"+truncSpace);
}

char GetSymbol()
{
    int val = rnd.Next(1, 10);
    if (val <5)
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }
    else
    {
        ConsoleColor c = rnd.Next(2, 6) switch
        {
            //1 => ConsoleColor.Green,
            2 => ConsoleColor.Red,
            3 => ConsoleColor.Yellow,
            4 => ConsoleColor.Blue,
            5 => ConsoleColor.White,
            _ => ConsoleColor.Magenta, //error color
        };
        Console.ForegroundColor = c;
    }
    char result = val switch
    {
        < 5 => '*',
        _ => 'o'
    };
    return result;
}