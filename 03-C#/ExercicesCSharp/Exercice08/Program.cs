Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Write("Entrer le prix HT (en €) de l'objet: ");
float price = float.Parse(Console.ReadLine()!);
Console.Write("Entrer le taux (en %) de la TVA: ");
float tax = float.Parse(Console.ReadLine()!);
float taxApplied = price * (tax/100);
Console.WriteLine($"Le montant de la TVA est de {taxApplied} €");
Console.WriteLine($"Le prix TTC de l'objet est de {(price+taxApplied)} €");