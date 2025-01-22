/*

# TP 3 - LINQ

### Exercices LINQ to Objects

using System;

Voici une liste de 10 exercices progressifs basés sur une liste d'objets `Person`. Chaque `Person` a les propriétés suivantes : `Id`, `Name`, `Age`, et `City`.

#### Données initiales
```csharp
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
```

#### Exercices

1. * *Trouver toutes les personnes de Paris.**
2. **Trouver les noms des personnes ayant plus de 30 ans.**
3. **Trier les personnes par âge croissant.**
4. **Compter le nombre de personnes vivant à Lyon.**
5. **Trouver la personne la plus âgée.**
6. **Obtenir une liste des villes distinctes.**
7. **Vérifier si toutes les personnes ont plus de 20 ans.**
8. **Projeter une nouvelle liste contenant uniquement les noms et âges.**
9. **Trouver le nom de la personne la plus jeune vivant à Paris.**
10. **Grouper les personnes par ville et afficher le nombre de personnes dans chaque ville.**
11. **Créer une séquence infinie de nombres pairs et récupérer les 10 premiers.**  
12. **Paginer une liste de nombres de 1 à 100 pour obtenir le 3ème bloc de 10 nombres (21 à 30).**
13. **Trouver le nombre maximum dans une liste d'entiers.** `[4, 8, 15, 16, 23, 42]`
14. **Filtrer les mots d'une liste contenant plus de 5 lettres.** `["chat", "ordinateur", "table", "lampe", "programme"]`

*/