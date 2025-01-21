namespace Demo01.Classes.CustomEnumerables;

public class CustomStack<T> : CustomEnumerable<T>
{
    public override T Pop() => Take(_values.Length - 1);
}