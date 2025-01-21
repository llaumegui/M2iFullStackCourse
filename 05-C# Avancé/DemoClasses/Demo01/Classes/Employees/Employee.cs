namespace Demo01.Classes.Employees;

public class Employee
{
    protected static int _nbrOfEmployees;
    protected static double _totalSalary;

    protected string? _name;
    protected double _salary;
    private string? _register;
    protected string? _category;

    public virtual double TotalSalary => _salary;
    public string? Name => _name;

    public Employee(string? name, double salary, string? register, string? category)
    {
        _name = name;
        _salary = salary;
        _register = register;
        _category = category;

        _nbrOfEmployees++;
        _totalSalary += _salary;
    }
    public Employee()
    {
        _name = "DefaultName";
        _salary = 1000;
        _register = "DefaultRegister";
        _category = "Salarié";

        _nbrOfEmployees++;
        _totalSalary += _salary;
    }

    public override string ToString() => $"{_name} est un {_category}\nIl a un salaire de {_salary}€";

    public static void ShowTotalSalary()
    {
        Console.WriteLine($"Il y a {_nbrOfEmployees} salariés, pour un salaire total de {_totalSalary}€");
    }

    public static void ResetCompanyFields()
    {
        _nbrOfEmployees = 0;
        _totalSalary = 0;
    }
}