namespace Demo01.Classes;

public static class WordGenerator
{
    private static Random _random = new Random();
    private static string[] _words =
    {
        "Guillaume", "TheoH", "TheoW", "Lucas", "Ronan", "Alexandre"
    };

    public static string GenerateRandomWord() { return _words[_random.Next(_words.Length)]; }
}