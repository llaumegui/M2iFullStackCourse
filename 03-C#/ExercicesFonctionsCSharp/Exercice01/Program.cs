string FullName(string firstName, string lastName) => $"{firstName} {lastName}";
// '=>' fonctionne de la même manière qu'un return
// C'est pratique lorsqu'on doit faire un rapide calcul ou pour ajouter juste un espace comme ici

// string FullName(string firstName, string lastName)
// {
//      return $"{firstName} {lastName}";
// };
Console.WriteLine("--- Nom complet ---\n");
Console.Write("Entrez votre nom: ");
string lastName = Console.ReadLine()!;
Console.Write("Entrez votre prénom: ");
string firstName = Console.ReadLine()!;

// On peut faire un appel de fonction directement dans le Console.WriteLine
// /!\ ça raccourcit le code mais il peut perdre en clarté!
Console.WriteLine($"Bonjour {FullName(firstName, lastName)}!");