Console.WriteLine("--- Calcul du périmètre et de l'aire d'un carré ---");
Console.Write("Entrez la longueur (en cm) d'un côté du carré: ");
float nbr = float.Parse(Console.ReadLine()!);
Console.WriteLine("Le périmètre du carré est: "+nbr*4 + "cm");
Console.WriteLine("L'aire du carré est: "+Math.Pow(nbr,2)+"cm");

Console.WriteLine("\n------------------\n");

Console.WriteLine("--- Calcul du périmètre et de l'aire d'un rectangle ---");
Console.Write("Entrez la longueur (en cm) du rectangle: ");
float length = float.Parse(Console.ReadLine()!);
Console.Write("Entrez la largeur (en cm) du rectangle: ");
float width = float.Parse(Console.ReadLine()!);
Console.WriteLine("Le périmètre du rectangle est: "+(length+width)*2 + "cm");
Console.WriteLine("L'aire du rectangle est: "+length*width+"cm");