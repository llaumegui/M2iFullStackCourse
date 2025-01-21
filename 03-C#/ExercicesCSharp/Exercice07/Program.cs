Console.WriteLine("--- Calcul de la longueur de l'hypothénuse ---");
Console.Write("Entrez la longueur (en cm) du 1e côté: ");
float opposite = float.Parse(Console.ReadLine()!);
Console.Write("Entrez la longueur (en cm) du 2e côté: ");
float adjacent = float.Parse(Console.ReadLine()!);
Console.WriteLine("L'hypothénuse : "+ Math.Sqrt(Math.Pow(opposite,2)+Math.Pow(adjacent,2)).ToString("N2") + "cm");