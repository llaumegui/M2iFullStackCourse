namespace Demo01.Classes.Persons;

public class Scientist : Worker
{
    public TypeOfScientist Type{ get; }
    public Subjects Subject{ get; }

    public Scientist(string firstName = "default", string lastName = "default", string telephoneNumber = "", string email = "",
        string companyName = "defaultName", string companyAddress = "", string professionalPhone = "",
        TypeOfScientist type = TypeOfScientist.Theorical, Subjects subject = Subjects.Mathematics)
        : base(firstName, lastName, telephoneNumber, email, companyName, companyAddress, professionalPhone)
    {
        Type = type;
        Subject = subject;
    }

    public override string ToString()
    {
        return base.ToString()+
               $"\nen tant que {Type} scientist in {Subject}";
    }
}

public enum TypeOfScientist
{
    Theorical,
    Experimental,
    Digital
}

public enum Subjects
{
    Mathematics,
    Physics,
    Chemistry,
}