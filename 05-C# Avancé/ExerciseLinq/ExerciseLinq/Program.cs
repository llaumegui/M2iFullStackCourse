using Person = (int Id, string Name, int Age, string City);
var people = new List<Person>
{
    (1, "Alice", 25, "Paris"),
    (2, "Bob", 30, "Lyon"),
    (3, "Charlie", 35, "Marseille"),
    (4, "Diana", 40, "Paris"),
    (5, "Eve", 28, "Lyon"),
    (6, "Frank", 33, "Paris")
};
void DisplayPerson(Person person)=>Console.WriteLine($"person n°{person.Id}: {person.Name}\n" +
                                     $"Age:{person.Age}\n" +
                                     $"City:{person.City}\n");

Console.WriteLine("----- EXERCICE 01 -----");
Exercise01();
Console.WriteLine("----- EXERCICE 02 -----");
Exercise02();
Console.WriteLine("----- EXERCICE 03 -----");
Exercise03();
Console.WriteLine("----- EXERCICE 04 -----");
Exercise04();
Console.WriteLine("----- EXERCICE 05 -----");
Exercise05();
Console.WriteLine("----- EXERCICE 06 -----");
Exercise06();
Console.WriteLine("----- EXERCICE 07 -----");
Exercise07();
Console.WriteLine("----- EXERCICE 08 -----");
Exercise08();
Console.WriteLine("----- EXERCICE 09 -----");
Exercise09();
Console.WriteLine("----- EXERCICE 10 -----");
Exercise10();
Console.WriteLine("----- EXERCICE 11 -----");
Exercise11();
Console.WriteLine("----- EXERCICE 12 -----");
Exercise12();
Console.WriteLine("----- EXERCICE 13 -----");
Exercise13();
Console.WriteLine("----- EXERCICE 14 -----");
Exercise14();

// Trouver toutes les personnes de Paris.
void Exercise01()
{
    people.Where(x => x.City == "Paris").ToList().ForEach(DisplayPerson);
}

// Trouver les noms des personnes ayant plus de 30 ans.
void Exercise02()
{
    //people.Where(x => x.Age > 30).ToList().ForEach(DisplayPerson);
    people.Where(x => x.Age > 30).Select(x=>x.Name).ToList().ForEach(Console.WriteLine);
}

// Trier les personnes par âge croissant.
void Exercise03()
{
    people.OrderBy(x => x.Age).ToList().ForEach(DisplayPerson);
}

// Compter le nombre de personnes vivant à Lyon.
void Exercise04()
{
    Console.WriteLine(people.Count(x => x.City == "Lyon"));
}

// Trouver la personne la plus âgée.
void Exercise05()
{
    DisplayPerson(people.OrderBy(x => x.Age).Last());
}

// Obtenir une liste des villes distinctes.
void Exercise06()
{ 
    people.GroupBy(x=>x.City).Select(x=>x.Key).ToList().ForEach(Console.WriteLine);
}

// Vérifier si toutes les personnes ont plus de 20 ans.
void Exercise07()
{
    Console.WriteLine((people.All(x => x.Age>20))?"Tout le monde a plus de 20 ans":"Quelqu'un a moins de 20 ans");
}

// Projeter une nouvelle liste contenant uniquement les noms et âges.
void Exercise08()
{ 
    people.Select(x=> new {x.Name,x.Age}).ToList().ForEach(x=>Console.WriteLine($"{x.Name} {x.Age}"));
}

// Trouver le nom de la personne la plus jeune vivant à Paris.
void Exercise09()
{
    DisplayPerson(people.Where(x=>x.City=="Paris").OrderBy(x=>x.Age).First());
}

// Grouper les personnes par ville et afficher le nombre de personnes dans chaque ville.
void Exercise10()
{
    //people.GroupBy(x=>x.City).ToList().ForEach(x=>Console.WriteLine($"{x.Key}: {x.Count()}"));
    people.GroupBy(p=>p.City)
        .Select(g=>new{City = g.Key,Count = g.Count()})
        .ToList().ForEach(Console.WriteLine);
}

// Créer une séquence infinie de nombres pairs et récupérer les 10 premiers.
void Exercise11()
{
    Enumerable.Range(0,Int32.MaxValue).Select(x=>x*2).Take(10).ToList().ForEach(x=>Console.WriteLine($"{x}"));
}

// Paginer une liste de nombres de 1 à 100 pour obtenir le 3ème bloc de 10 nombres (21 à 30).
void Exercise12()
{
    //Enumerable.Range(1,100).Skip(20).Reverse().Skip(70).Reverse().ToList().ForEach(x=>Console.WriteLine($"{x}"));
    Enumerable.Range(1,100).Skip(20).Take(10).ToList().ForEach(x=>Console.WriteLine($"{x}"));
}

// Trouver le nombre maximum dans une liste d'entiers. [4, 8, 15, 16, 23, 42]
void Exercise13()
{
    int[] arr = [4, 8, 15, 16, 23, 42];
    Console.WriteLine(arr.Max());
}

// Filtrer les mots d'une liste contenant plus de 5 lettres. ["chat", "ordinateur", "table", "lampe", "programme"]
void Exercise14()
{
    string[] arr = ["chat", "ordinateur", "table", "lampe", "programme"];
    arr.Where(x=>x.Length>5).ToList().ForEach(x=>Console.WriteLine($"{x}"));
}

