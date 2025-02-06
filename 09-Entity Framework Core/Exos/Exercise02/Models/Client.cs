namespace Exercise02.Models;

public class Client
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public List<Booking> Bookings { get; set; } = [];

    public string DisplayBookings()
    {
        string result = "";
        foreach (var booking in Bookings)
        {
            result += booking.DisplayStatus()+Environment.NewLine;
        }
        return result;
    }
}