Console.WriteLine("--- Accroissement ---\n");
float population = 96809;
int year = 2015, newYear = 2015;

while (population < 120000)
{
    population += population*.0089f;
    newYear++;
}
Console.WriteLine($"Il faudra {newYear-year} ans, nous serons en {newYear}!");
Console.WriteLine($"Il y aura {(int)population} en {newYear}!");
