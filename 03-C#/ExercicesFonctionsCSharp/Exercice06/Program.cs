(float add, float sub, float mult, float div) Operations(float nbr1, float nbr2)
    => (nbr1 + nbr2, nbr1 - nbr2, nbr1 * nbr2, (nbr2 == 0 ? 0 : nbr1 / nbr2));
// on peut tester une condition avec une expression ternaire
// ((condition) ? resultat quand la condition est vraie : condition quand elle est fausse));
// si tu divises par 0, le monde explose, on doit donc tester la condition si le diviseur est 0

Console.WriteLine("--- Tuple d'opérations ---\n");
Console.Write("Entrez le 1e nombre: ");
float.TryParse(Console.ReadLine()!, out float number1);
// TryParse va essayer de convertir le texte en nombre, retournera 0 si il ne peut pas
// 'out' dans cette fonction va stocker la valeur convertie dans le float number1

Console.Write("Entrez le 2e nombre: ");
float.TryParse(Console.ReadLine()!, out float number2);
var tuple = Operations(number1, number2);

Console.WriteLine($"{number1} + {number2} = {tuple.add:0.##}\n" +
                  $"    {number1} - {number2} = {tuple.sub:0.##}\n" +
                  $"        {number1} / {number2} = {(number2 == 0 ? "ERREUR MATHÉMATIQUE" : $"{tuple.div:0.##}")}\n" +
                  $"            {number1} x {number2} = {tuple.mult:0.##}");

//:0.## est une méthode de formatage plus rapide
// ':' annonce un formatage
// '0.' force le nombre à marquer la valeur avant la virgule même si elle est de 0
// .## indique d'afficher 2 nombres après la virgule, mais si ce nombre est 0, il n'affiche rien
// :N2 fonctionne comme au dessus, le chiffre après le N indique le nombre de chiffres après la virgule