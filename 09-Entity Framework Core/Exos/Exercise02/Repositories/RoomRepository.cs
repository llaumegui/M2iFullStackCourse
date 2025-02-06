using Exercise02.Data;
using Exercise02.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Exercise02.Repositories;

public class RoomRepository(ApplicationDbContext db) : IRepository<Room, int>
{
    public bool Add(Room obj)
    {
        EntityEntry<Room> entry = db.Entry(obj);
        return db.SaveChanges() == 1;
    }

    public Room? GetById(int id) => db.Rooms.FirstOrDefault(r => r.Id == id);
    
    public Room? Get(Func<Room, bool> predicate)=> db.Rooms.FirstOrDefault(predicate);
    
    public IEnumerable<Room> GetAll() => db.Rooms;
    
    public IEnumerable<Room> GetAll(Func<Room, bool> predicate) => db.Rooms.Where(predicate);

    public bool Delete(int id)
    {
        var room = GetById(id);
        if (room == null)
            return false;

        db.Rooms.Remove(room);
        return Save();
    }

    public bool Save() => db.SaveChanges() > 0;
}