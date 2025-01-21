bool TestAdn(string test)
{
    // le foreach fonctionne de la même manière qu'un 'for' mais est plus pratique
    // si on a pas besoin d'un index particulier pour notre fonction
    foreach (char t in test)
        if (!"atcg".Contains(t)) // ici le '!' indique que l'on veut tester une condition qui est fausse
            return false;
    // le Contains() va regarder si le charactère 't' est présent dans le tableau de charactère test
    // oui un string est un tableau de character et pas seulement un slip pas super confortable

    return true;
    // si tous les character testé sont elligibles, la fonction return true automatiquement
}

float Proportion(string chain, string sequence)
{
    if (!TestAdn(chain)) return -1;
    int count = chain.Split(sequence).Length - 1; // fonctionnement similaire à l'exo précédent
    return ((float)(count * sequence.Length) / chain.Length) * 100; // formule classique de pourcentage
}

bool test;
string sequence;
// initialiser en dehors des boucles les variables pour pouvoir les récupérer plus tard
Console.WriteLine("--- ADN ---\n");
do
{
    Console.Write("Entrez la séquence ADN à retrouver: ");
    sequence = Console.ReadLine()!.ToLower();
    test = TestAdn(sequence);
    if (!test)
    {
        Console.WriteLine("La séquence ADN est incorrect.");
    }
} while (!test);

string chain;
do
{
    Console.Write("Saisir la chaîne ADN à comparer: ");
    chain = Console.ReadLine()!.ToLower();
    test = TestAdn(chain);
    if (!test)
    {
        Console.WriteLine("La séquence ADN est incorrect.");
    }
} while (!test);

float proportion = Proportion(chain, sequence);
Console.WriteLine($"Il y a {proportion:N2}% d'occurences de la séquence ADN dans la chaîne");