Console.WriteLine("--- Le nombre est-t-il divisible par ...? ---\n");
Console.Write("Entrez un nombre entier: ");
int nbr = Convert.ToInt32(Console.ReadLine());
Console.Write("Entrez un nombre diviseur: ");
int divide = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(nbr + (nbr % divide==0? " est divisible par ":" n'est pas divisible par ")+ divide);