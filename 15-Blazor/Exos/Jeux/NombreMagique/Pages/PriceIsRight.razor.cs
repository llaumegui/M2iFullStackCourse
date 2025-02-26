using Microsoft.AspNetCore.Components;

namespace NombreMagique.Pages;

public partial class PriceIsRight
{
    private int _winValue;
    private int _tries = 5;
    private bool _end;

    public int Minimum = 0;
    public int Maximum = 20;

    public int Tries
    {
        get => _tries;
        set
        {
            _tries = value;
            UpdateTriesText();
        }
    }

    public string TriesText { get; private set; } = string.Empty;
    public string Message { get; private set; } = "";
    public int TestValue { get; private set; } = 0;

    protected override void OnInitialized()
    {
        var rdm = new Random();
        _winValue = rdm.Next(Minimum, Maximum+1);
        
        UpdateTriesText();
    }

    private void UpdateTriesText()
    {
        TriesText = string.Empty;
        for (int i = 0; i < Tries; i++)
            TriesText += "&#10084 ";
    }

    private void ValidateTry()
    {
        if (TestValue < Minimum || TestValue > Maximum || _end)
            return;
        
        if (TestValue == _winValue)
        {
            Message = "Vous avez Gagné!";
            _end = true;
        }
        else
        {
            _tries--;
            Message = _tries > 0
                ? $"Le nombre a trouver est plus {(TestValue > _winValue ? "petit" : "grand")}!"
                : "Vous Avez Perdu!";
            _end = _tries == 0;
            UpdateTriesText();
        }
    }
}