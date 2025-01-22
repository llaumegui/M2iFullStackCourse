namespace Demo01.Classes.Persons;

public class Worker : Person
{
    public string CompanyName { get; }
    public string CompanyAddress { get; }
    public string ProfessionalPhone { get; }

    public Worker( string firstName = "default", string lastName = "default", string telephoneNumber = "", string email = "",
        string companyName ="defaultName", string companyAddress="", string professionalPhone="")
        : base(firstName, lastName, telephoneNumber, email)
    {
        CompanyName = companyName;
        CompanyAddress = companyAddress;
        ProfessionalPhone = professionalPhone;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nTravail à {CompanyName}," +
               $"{CompanyAddress}" +
               $"{ProfessionalPhone}";
    }
}