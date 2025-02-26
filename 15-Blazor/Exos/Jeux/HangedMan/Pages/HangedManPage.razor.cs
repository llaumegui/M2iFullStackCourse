using HangedMan.Classes;
using Microsoft.AspNetCore.Components;

namespace HangedMan.Pages;

public partial class HangedManPage : ComponentBase
{
    private List<char> _triedKeys = [];

    private string _wordToFind = string.Empty;
    public string WordDisplay = string.Empty;
    public int HangedTries;
    public bool End;
    public string EndMessage;

    public void TryLetter(char letter)
    {
        _triedKeys.Add(letter);

        bool found = _wordToFind.Contains(letter, StringComparison.InvariantCultureIgnoreCase);
        string temp = string.Empty;
        if (found)
            for (int i = 0; i < _wordToFind.Length; i++)
            {
                if (string.Compare(_wordToFind[i].ToString(), letter.ToString(),
                        StringComparison.InvariantCultureIgnoreCase) == 0)
                    temp += _wordToFind[i];
                else
                    temp += WordDisplay[i];
            }
        else
            HangedTries++;

        WordDisplay = temp == string.Empty ? WordDisplay : temp;

        TestEnd();
    }

    protected override void OnInitialized()
    {
        _triedKeys.Clear();
        HangedTries = 0;
        End = false;
        _wordToFind = Tools.WordGenerator();
        WordDisplay = new string('*', _wordToFind.Length);
        EndMessage = string.Empty;
    }

    private void TestEnd()
    {
        if (HangedTries == 10)
        {
            End = true;
            EndMessage += "Vous avez perdu!";
        }

        if (string.Compare(WordDisplay, _wordToFind, StringComparison.InvariantCultureIgnoreCase) == 0)
        {
            End = true;
            EndMessage += "Vous avez gagné!";
        }
    }
}