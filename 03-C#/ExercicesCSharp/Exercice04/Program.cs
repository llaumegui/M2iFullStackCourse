Console.Write("Veuillez saisir votre nom: ");
string lastName = Console.ReadLine()!;
Console.Write("Veuillez saisir votre prénom: ");
string firstName = Console.ReadLine()!;
Console.Write("Veuillez saisir votre âge: ");
int age = int.Parse(Console.ReadLine());

Console.WriteLine($"Bonjour {firstName} {lastName}, vous avez {age}!");