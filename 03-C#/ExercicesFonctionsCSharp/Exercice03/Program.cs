Console.WriteLine("--- Quelle heure? ---\n");
string Hour(string hour = "12:00") => $"Il est {hour}";
// on peut mettre une valeur par défaut à un paramètre d'une fonction
// Ici, quand on ne donne rien à la valeur 'hour', il retournera automatiquement "12:00"

Console.WriteLine(Hour("14:00")); // 14:00
Console.WriteLine(Hour()); // 12:00