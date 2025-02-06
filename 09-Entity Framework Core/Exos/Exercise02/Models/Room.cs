using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Exercise02.Models;

[Index(nameof(Number),IsUnique = true)]
public class Room
{
    public int Id { get; set; }
    public int Number { get; set; }
    public RoomStatus Status { get; set; }
    public int NumberOfBeds { get; set; }
    public float Price { get; set; }
    public Hotel Hotel { get; set; }
    public Booking? Booking { get; set; }

    public override string ToString() =>
        $"\nChambre {Number} - Status: {nameof(Status)}";

}

public enum RoomStatus
{
    Available,
    Occupied,
    Cleaning
}