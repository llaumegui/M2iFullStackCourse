namespace Demo01.Classes.CustomEnumerables;

public abstract class CustomEnumerable<T>
{
    protected T[]? _values = [];
    public int Count => _values!.Length;
    public T? this[int index]=>_values?.Length==0 ? default(T) :_values![index];

    public abstract T Pop();
    
    public void Push(T value)
    {
        T[] newValues = new T[Count+1];
        for(int i=0;i<Count;i++)
            newValues[i] = _values![i];
        newValues[newValues.Length - 1] = value;
        _values = newValues;
    }
    public T Take(int index)
    {
        T val = default!;
        val = _values[index];
        Remove(_values[index]);
        return val;
    }

    public bool Contains(T value)
    {
        foreach (T item in _values!)
            if(value!.Equals(item))
                return true;
        
        return false;
    }
    
    public void Remove(T value)
    {
        for(int i=0;i<_values.Length;i++)
            if(_values[i]!.Equals(value))
                RemoveAt(i);
    }

    public void RemoveAt(int index)
    {
        T[] temp = new T[_values!.Length - 1];
        bool found = false;
        
        for (int i = 0; i < _values.Length; i++)
        {
            if (i == index)
            {
                found = true;
                continue;
            }
            if(found)
                temp[i-1] = _values[i];
            else
                temp[i] = _values[i];
        }
        _values = temp;
    }

    
    public override string ToString()
    { 
        string result = "";
        for(int i=0;i<Count;i++)
            result += $"{(_values[i]?.ToString() ?? "null")},\n";
        return result;
    }
}
