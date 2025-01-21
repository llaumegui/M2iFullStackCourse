Console.WriteLine("--- Insertion des valeurs du tableau ---\n");
Console.WriteLine("Combien de nombres contiendra le tableau?: ");
int max = Convert.ToInt32(Console.ReadLine());
int[] t = new int[max];
for (int i = 0; i < max; i++)
{
    Console.WriteLine($"Insérer la valeur {i+1} du tableau: ");
    t[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("Affichage des valeurs du tableau: ");
for (int i = 0; i < t.Length; i++)
    Console.Write((i>0?"\n"+new string(' ',(i*5)):"")+t[i]);
