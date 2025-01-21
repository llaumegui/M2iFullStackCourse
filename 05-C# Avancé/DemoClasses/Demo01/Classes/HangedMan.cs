namespace Demo01.Classes;

public class HangedMan
{
    private string _wordToFind, _mask, _charsCalled = "";
    private int _nbrOfTries, _tryCount = 0;

    public string Mask => _mask;
    public int TriesRemaining => _nbrOfTries - _tryCount;

    public HangedMan(int nbrOfTries = 10)
    {
        _nbrOfTries = nbrOfTries;
        _wordToFind = WordGenerator.GenerateRandomWord();
        _mask = new string('*', _wordToFind.Length);
    }

    public string TestChar(string s)
    {
        if (s == "")
            return ThrowError(ErrorType.EmptySelection);

        if (s.Length > 1)
            return TestString(s);

        if (!char.IsLetter(s[0]))
            return ThrowError(ErrorType.NotALetter);

        char c = char.ToLower(s[0]);
        if (_charsCalled.Contains(s))
            return ThrowError(ErrorType.AlreadyCalled);

        _charsCalled += c;
        if (!_wordToFind.ToLower().Contains(s))
            _tryCount++;

        return UpdateMask(s[0]);
    }

    private string TestString(string s)
    {
        _tryCount = TestWin(s) ? _tryCount : _tryCount + 1;
        return _mask;
    }

    private string UpdateMask(char c)
    {
        char[] temp = _mask.ToCharArray();
        for (int i = 0; i < _mask.Length; i++)
            if (char.ToLower(_wordToFind[i]) == c)
                temp[i] = _wordToFind[i];

        _mask = new string(temp);
        return _mask;
    }

    private string ThrowError(ErrorType type)
    {
        string s = type switch
        {
            ErrorType.EmptySelection => "la selection envoyée est vide",
            ErrorType.NotALetter => "le charactère choisi n'est pas une lettre.",
            ErrorType.AlreadyCalled => $"la lettre a déjà été appellée",
            _ => ""
        };
        return s;
    }

    public bool TestWin()
    {
        return string.Equals(_mask, _wordToFind, StringComparison.CurrentCultureIgnoreCase) && TriesRemaining > 0;
    }

    private bool TestWin(string s)
    {
        if (string.Equals(s, _wordToFind, StringComparison.CurrentCultureIgnoreCase) && TriesRemaining > 0)
        {
            _mask = _wordToFind;
            return true;
        }

        return false;
    }
}

public enum ErrorType
{
    NotALetter,
    EmptySelection,
    AlreadyCalled
}