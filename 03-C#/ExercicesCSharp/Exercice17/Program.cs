Console.WriteLine("--- Dans quelle catégorie mon enfant est-il? ---\n");
Console.Write("Entrer l'âge de votre enfant: ");
int age = Convert.ToInt32(Console.ReadLine());
string message = "";
switch (age)
{
    case < 3:
        message = "Votre enfant est trop jeune";
        break;
    case <= 6: 
        message = "Votre enfant est de la catégorie \"Baby\"";
        break;
    case <= 8:
        message = "Votre enfant est de la catégorie \"Poussin\"";
        break;
    case <= 10:
        message = "Votre enfant est de la catégorie \"Pupille\"";
        break;
    case <= 12:
        message = "Votre enfant est de la catégorie \"Minime\"";
        break;
    case < 18:
        message = "Votre enfant est de la catégorie \"Cadet\"";
        break;
    default:
        message = "Votre enfant n'est plus un gosse m'enfin!";
        break;
}
Console.WriteLine(message);