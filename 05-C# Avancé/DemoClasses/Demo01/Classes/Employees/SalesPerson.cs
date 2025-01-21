namespace Demo01.Classes.Employees;

public class SalesPerson : Employee
{
    private double _turnover;
    private double _commission;

    public override double TotalSalary => _salary + (_commission / 100) * _turnover;

    public SalesPerson(string? name, double salary, string? register, string? category,
        double turnover, double commission) : base(name, salary, register, category)
    {
        _turnover = turnover;
        _commission = commission;
    }

    public SalesPerson() : base()
    {
        _turnover = 1000;
        _commission = 10;
        _category = "Commercial";
    }

    public override string ToString()
    {
        return base.ToString() + $"\nSon salaire avec commissions est de {TotalSalary}€";
    }
}