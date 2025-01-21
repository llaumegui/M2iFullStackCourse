namespace Demo01.Classes.CustomEnumerables;

public class CustomQueue<T> : CustomEnumerable<T>
{
    public override T Pop() => Take(0);
}