Console.WriteLine("--- Affichage de l'alphabet ---\n");

int id = 65; //id for A in Ascii
int[] tab = new int[26];
for (int i = 0; i < tab.Length; i++)
{
    tab[i] = id + i;
}
for (int i = 0;i< tab.Length; i++)
{
    Console.Write((i>0?"\n"+new string(' ',(i)):"")+(char)(tab[i]));
}