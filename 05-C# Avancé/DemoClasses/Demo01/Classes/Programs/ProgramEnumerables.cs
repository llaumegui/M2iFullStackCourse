using Demo01.Classes.CustomEnumerables;
using Demo01.Classes.Menus;

bool isStack = true;
CustomEnumerable<string> s;
if (isStack)
    s = new CustomStack<string>();
else
    s = new CustomQueue<string>();
string type = isStack ? "Pile" : "Queue";
Menu mainMenu = new Menu("Menu Principal", new Dictionary<string, ConditionValue>
{
    { "1", new ConditionValue("Empiler") },
    { "2", new ConditionValue("Dépiler", true) },
    { "3", new ConditionValue("Récupérer à X", true) },
    { "4", new ConditionValue($"Afficher {type}") },
    { "0", new ConditionValue("Quitter") },
});
bool condition = false;
string menuKey = "";
Console.WriteLine(s.Count);
while (true)
{
    while (true)
    {
        Console.Clear();
        condition = s.Count > 0;
        Console.WriteLine($"=== {mainMenu.Title} ===");
        foreach (KeyValuePair<string, ConditionValue> kvp in mainMenu.MenuItems)
        {
            if (kvp.Value.Condition == condition || !kvp.Value.Condition)
                Console.ResetColor();
            else
                Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"{kvp.Key}. {kvp.Value}");
        }

        Console.Write("Votre choix: ");
        if (mainMenu.TryKey(Console.ReadLine(), condition, out menuKey))
            break;
    }
    Console.Clear();
    if(menuKey == "0")
        break;
    string txt = "";
    switch (menuKey)
    {
        case "1":
            Console.Write("Valeur à empiler: ");
            txt = Console.ReadLine();
            s.Push(txt);
            Console.WriteLine($"{txt} a été ajoutée à la {type}");
            break;
        case "2":
            s.Pop();
            Console.WriteLine("Valeur retirée avec succès");
            break;
        case "3":
            Console.Write("Index de la valeur: ");
            int.TryParse(Console.ReadLine(), out int index); 
            txt = s.Take(index);
            Console.WriteLine($"La valeur récupérée est: {s[index]}");
            break;
        case "4":
            Console.WriteLine($"{type} {nameof(s)}:\n{s}");
            break;
    }
    Console.Write("Appuyez sur Entrée pour continuer");
    Console.ReadLine();
}