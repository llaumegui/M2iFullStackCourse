Console.WriteLine("--- La lettre est-elle une voyelle ? ---\n");
Console.Write("Entrez une lettre: ");
string letter = Console.ReadLine()!.ToLower();
Console.WriteLine("Cette lettre est une "+("aeiouyéàèùâêîôûëïü".Contains(letter[0])?"voyelle":"consonne"));