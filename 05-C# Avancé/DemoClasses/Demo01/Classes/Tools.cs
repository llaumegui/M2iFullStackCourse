namespace Demo01.Classes;

public static class Tools
{
    private static Random _rnd = new Random();
    private static string[] _adressSuffixes =
    {
        "de l'Olivier", "du Cocotier", "des frères Théaux", "du gros porc"
    };

    public static string TelephoneGenerator()
    {
        return
            $"+33 {_rnd.Next(6, 8)}" +
            $" {_rnd.Next(0, 100).ToString("00")}" +
            $" {_rnd.Next(0, 100).ToString("00")}" +
            $" {_rnd.Next(0, 100).ToString("00")}" +
            $" {_rnd.Next(0, 100).ToString("00")}";
    }

    public static string EmailGenerator()
    {
        Random rnd = new Random();
        string result = "";
        for (int i = 0; i < rnd.Next(11); i++)
            result += (char)rnd.Next(97, 123);
        return result + "@llaumegui.com";
    }

    public static string AddressGenerator() => $"{_rnd.Next(101)} " +
                                               $"{(_rnd.Next(2)==0?"rue":"avenue")} " +
                                               $"{_adressSuffixes[_rnd.Next(0, _adressSuffixes.Length)]}";
}