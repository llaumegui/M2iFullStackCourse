Console.WriteLine("--- Dans quelle catégorie mon enfant est-il? ---\n");
Console.Write("Entrer l'âge de votre enfant: ");
int age = Convert.ToInt32(Console.ReadLine());
string message = "";
if (age < 3)
    message = "Votre enfant est trop jeune";
else if (age <= 6)
    message = "Votre enfant est de la catégorie \"Baby\"";
else if (age <= 8)
    message = "Votre enfant est de la catégorie \"Poussin\"";
else if (age <= 10)
    message = "Votre enfant est de la catégorie \"Pupille\"";
else if (age <= 12)
    message = "Votre enfant est de la catégorie \"Minime\"";
else if (age < 18)
    message = "Votre enfant est de la catégorie \"Cadet\"";
else
    message = "Votre enfant n'est plus un gosse m'enfin!";
Console.WriteLine(message);