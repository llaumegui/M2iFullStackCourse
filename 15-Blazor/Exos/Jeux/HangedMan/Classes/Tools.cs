namespace HangedMan.Classes;

public class Tools
{
    private static string[] words =
    {
        "chat", "maison", "soleil", "arbre", "fleur", "rouge", "rapide",
        "ballon", "sourire", "musique", "plage", "montagne", "danse", "avion",
        "étoile", "rivière", "lumière", "cerise", "bateau", "matin"
    };
    public static string WordGenerator()=>words[new Random().Next(0, words.Length)];
}