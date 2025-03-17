namespace exo04.ViewModels;

public class BindingHangedManViewModel
{
    public int ErrorCount;
    public string HangmanPath => $"hangman_0{ErrorCount + 1}.png";
    public string Keys = "AZERTYUIOPQSDFGHJKLMWXCVBN";
    
    
}