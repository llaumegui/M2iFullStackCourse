Console.WriteLine("--- Pair ou Impair? ---\n");
Console.Write("Combien de nombres contiendra le tableau?: ");
int max = Convert.ToInt32(Console.ReadLine());
int[] t = new int[max];
Random r = new Random();
Console.WriteLine("Affectation automatique des valeurs\n");
Console.WriteLine("Vérification des valeurs:");
for (int i = 0; i < max; i++)
    t[i] = r.Next(1, 51);
for (int i = 0; i < max; i++)
    Console.WriteLine($"Le nombre {t[i]} est " + (t[i] % 2 == 0 ? "pair." : "impair."));