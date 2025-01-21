Console.WriteLine("--- Tables des multiplications ---\n");
int i = 1, j = 1;
while (i <= 10)
{
    Console.WriteLine("Table de " + i +":");
    while (j <= 10)
    {
        Console.WriteLine($"    - {i} x {j} = {i * j}");
        j++;
    }
    i++;
    j = 1;
}