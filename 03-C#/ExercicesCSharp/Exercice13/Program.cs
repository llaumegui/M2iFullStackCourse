Console.WriteLine("--- Quelle est la nature du triangle ABC? ---\n");
Console.Write("Entrez la longueur du segment AB: ");
float ab = float.Parse(Console.ReadLine()!);
Console.Write("Entrez la longueur du segment BC: ");
float bc = float.Parse(Console.ReadLine()!);
Console.Write("Entrez la longueur du segment CA: ");
float ca = float.Parse(Console.ReadLine()!);
string msg = "";
if (ab != bc && bc != ca && ca != ab)
    msg = "Le triangle n'est isocèle ni en A ni en B ni en C";
else
{
    string isosceles = "Le triangle est isocèle en ";
    if (ab == bc && bc == ca && ca == ab)
        msg = "Le triangle est équilatéral";
    else if (ab == ca)
        msg = isosceles + "A";
    else if (bc == ab)
        msg = isosceles + "B";
    else
        msg = isosceles + "C";
}
Console.WriteLine(msg);
