Console.WriteLine("--- Quelle taille dois-je prendre? ---\n");
Console.Write("Entrez votre taille (en cm): ");
int height = Convert.ToInt32(Console.ReadLine());
Console.Write("Entrez votre poids (en kg): ");
int weight = Convert.ToInt32(Console.ReadLine());
string msg = "";
string outsized = "Vous êtes hors taille";
string size1 = "Vous êtes taille 1";
string size2 = "Vous êtes taille 2";
string size3 = "Vous êtes taille 3";
if (weight >= 43 && weight <= 77 && height >= 145 && height <= 183)
{
    if (weight <= 47)
    {
        if (height <= 169)
            msg = size1;
        else
            msg = outsized;
    }
    else if (weight <= 53)
    {
        if (height <= 166)
            msg = size1;
        else if (height <= 178)
            msg = size2;
        else
            msg = outsized;
    }
    else if (weight <= 59)
    {
        if (height <= 163)
            msg = size1;
        else if (height <= 175)
            msg = size2;
        else
            msg = size3;
    }

    if (weight >= 60 && weight <= 65)
    {
        if (height <= 160)
            msg = size1;
        else if (height <= 172)
            msg = size2;
        else
            msg = size3;
    }

    if (weight >= 66 && weight <= 71)
    {
        if (height <= 157)
            msg = outsized;
        else if (height <= 169)
            msg = size2;
        else
            msg = size3;
    }

    if (weight >= 72)
    {
        if (height <= 160)
            msg = outsized;
        else
            msg = size3;
    }
}
else
    msg = outsized;

Console.WriteLine(msg);