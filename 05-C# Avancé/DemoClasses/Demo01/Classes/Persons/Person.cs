namespace Demo01.Classes.Persons;

public abstract class Person
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Name => $"{FirstName} {LastName}";
    public string TelephoneNumber { get; }
    public string Email { get; }

    public Person(string firstName = "default",string lastName = "default",
        string telephoneNumber = "", string email = "")
    {
        FirstName = firstName;
        LastName = lastName;
        TelephoneNumber = telephoneNumber == "" ? Tools.TelephoneGenerator():telephoneNumber;
        Email = email == "" ? Tools.EmailGenerator() : email;
    }

    public override string ToString()
    {
        return $"{Name}\nPhone: {TelephoneNumber}\nMail: {Email}";
    }
}