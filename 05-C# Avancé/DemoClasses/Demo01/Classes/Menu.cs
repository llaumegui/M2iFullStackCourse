namespace Demo01.Classes.Menus;

public class Menu
{
    private string _title;
    public string Title => _title;
    private Dictionary<string, ConditionValue> _menuItems;
    public Dictionary<string, ConditionValue> MenuItems => _menuItems;
    
    public Menu(string title, Dictionary<string, ConditionValue> menuItems)
    {
        _title = title;
        _menuItems = menuItems;

        foreach (KeyValuePair<string, ConditionValue> menuItem in menuItems)
            if (menuItem.Key == "-1")
                throw new ArgumentException($"La clé {menuItem.Key} ne doit pas être égale à -1");
    }

    public Menu(string title, List<string> menuItems)
    {
        _title = title;
        _menuItems = new Dictionary<string, ConditionValue>();
        for (int i = 0; i < menuItems.Count; i++)
            _menuItems.Add((i+1).ToString(), new ConditionValue(menuItems[i]));
    }


    public bool TryKey(string testKey, out string key)
    {
        if (_menuItems.ContainsKey(testKey))
        {
            key = testKey;
            return true;
        }
        else
        {
            key = "-1";
            return false;
        }
    }

    public bool TryKey(string testKey, bool condition, out string key)
    {
        bool containsKey = _menuItems.ContainsKey(testKey);
        if ((containsKey && !_menuItems[testKey].Condition)
            || (containsKey && (condition == _menuItems[testKey].Condition)))
        {
            key = testKey;
            return true;
        }
        else
        {
            key = "-1";
            return false;
        }
    }

    public override string ToString()
    {
        string msg = $"=== {_title} ===\n";
        foreach (KeyValuePair<string, ConditionValue> kvp in _menuItems)
            msg += $"{kvp.Key}. {kvp.Value}\n";
        return msg;
    }
}

public struct ConditionValue
{
    public ConditionValue(string value, bool condition = false)
    {
        Value = value;
        Condition = condition;
    }

    public string Value { get; }
    public bool Condition { get; }

    public override string ToString() => Value;
}