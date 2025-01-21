Console.WriteLine("--- Menus et sous-menus ---\n");
Console.WriteLine("Table des matières");
int i = 1, j = 1;
while (i <= 3)
{
    Console.WriteLine("Chapitre " + i +":");
    while (j <= 3)
    {
        Console.WriteLine($"    -Partie {i}.{j}");
        j++;
    }
    i++;
    j = 1;
}