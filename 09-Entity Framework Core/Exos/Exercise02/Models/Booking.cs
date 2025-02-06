using System.ComponentModel.DataAnnotations;

namespace Exercise02.Models;

public class Booking
{
    public int Id { get; set; }
    public BookingStatus Status { get; set; } = BookingStatus.Foreseen;
    public List<Room> Rooms { get; set; } = [];
    
    public Client Client { get; set; }

    public override string ToString()
    {
        string result =  DisplayStatus()+
                        $":\nClient {Client.FullName}:\n";
        foreach (var room in Rooms)
        {
            result += room.ToString() + Environment.NewLine;
        }
        return result;
    }

    public string DisplayStatus() => $"Reservation n°{Id} - Status: {Status}";
}

public enum BookingStatus
{
    Foreseen,
    OnGoing,
    Finished,
    Cancelled,
}