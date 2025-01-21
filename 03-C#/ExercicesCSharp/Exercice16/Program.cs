Console.WriteLine("--- Quelle boisson souhaitez-vous? ---\n");
Console.WriteLine("Liste des boissons disponibles: \n   1.Eau Plate\n   2.Eau Gazeuse\n   3.Coca-Cola\n   4.Fanta\n   5.Sprite\n   6.Orangina\n   7.7up");
Console.Write("Faites votre choix (1 à 7): ");
int choice = Convert.ToInt32(Console.ReadLine());
string msg = choice switch
{
    1 => "Eau Plate",
    2 => "Eau Gazeuse",
    3 => "Coca-Cola",
    4 => "Fanta",
    5 => "Sprite",
    6 => "Orangina",
    7 => "7up",
    _ => ""
};
Console.WriteLine(choice<1||choice>7?"mauvais choix":$"Votre {msg} est servi!");
