using System.Collections.Specialized;

namespace exo04.ViewModels;

public class BindingHangedManViewModel
{
    public int ErrorCount = 0;
    public string HangmanPath => $"hangman_0{ErrorCount + 1}.png";
    public string Letters = "AZERTYUIOPQSDFGHJKLMWXCVBN";
}