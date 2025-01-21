int CountA(string chain)
{
    int count = 0; ;
    foreach (char c in chain)
        if (c == 'a')
            count++;
    return count;
}

int AltCountA(string chain) => chain.Split('a').Length - 1;
// Split transforme un string en tableau de strings dont chaque élément est "coupé" avec un séparateur (ici 'a')
// Exemple:
// eaeeeaeeeea => {"e","eee","eeee",""}     tableau composé de 4 éléments puisque il y avait 3 séparateurs

Console.WriteLine("--- Compteur de lettres A ---\n");

Console.Write("Entrez le mot à tester: ");
string test = Console.ReadLine()!.ToLower();
// ToLower est pas obligatoire mais permet de rendre homogène un string
// puisque 'A' n'est pas pareil que 'a' même si c'est la même lettre
Console.WriteLine($"Il y a {CountA(test)} de lettres 'a' dans la chaîne {test}!");
Console.WriteLine($"ALT | Il y a {AltCountA(test)} de lettres 'a' dans la chaîne {test}!");