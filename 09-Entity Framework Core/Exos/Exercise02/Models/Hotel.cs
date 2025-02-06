namespace Exercise02.Models;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Room> Rooms { get; set; } = [];
    public List<Booking> Bookings { get; set; } = [];

    public override string ToString() =>
        $"Hôtel {Name}:" +
        $"\nNombre de chambres: {Rooms.Count}" +
        $"\nNombre de réservations: {Bookings.Count}";
}