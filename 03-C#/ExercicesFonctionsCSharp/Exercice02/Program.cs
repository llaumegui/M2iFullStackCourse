int Substract(int nbr1 = 0, int nbr2 = 0) => (nbr1 - nbr2);

Console.WriteLine("--- Soustraction ---\n");
Console.Write("Entrez le nombre à soustraire: ");
int number1 = int.Parse(Console.ReadLine()!); // Parse fonctionne de la même manière que ConvertTo...
Console.Write("Entrez le 2e nombre: ");
int number2 = int.Parse(Console.ReadLine()!);

Console.WriteLine($"{number1} - {number2} = {Substract(number1, number2)}");
// La structure est exactement la même que dans l'exo précédent