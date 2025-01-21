Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("--- Quelle sera le montant de l'indemnité de licenciement? ---\n");
Console.Write("Entrez le montant de votre dernier salaire (en €): ");
double salary = Convert.ToDouble(Console.ReadLine());
Console.Write("Entrez votre âge: ");
int age = Convert.ToInt32(Console.ReadLine());
Console.Write("Entrez le nombre d'années d'ancienneté: ");
int seniority = Convert.ToInt32(Console.ReadLine());
double firstIndemnity = 0, secondIndemnity = 0;
if (seniority > 1)
{
    if (seniority <= 10)
        firstIndemnity = (salary / 2) * seniority;
    else
        firstIndemnity = salary * seniority;   
}
if (age > 45)
    secondIndemnity = age < 50 ? salary * 2 : salary * 5;
Console.WriteLine($"Votre indemnité est de: {firstIndemnity + secondIndemnity:N2}€");