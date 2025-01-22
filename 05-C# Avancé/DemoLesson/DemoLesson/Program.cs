using System.IO.Compression;

Action<int, int> print = (i, j) => Console.WriteLine(i + ", " + j);
Func<int, int, int> sum = (i, j) => i + j;
print(1, sum(1, 2));