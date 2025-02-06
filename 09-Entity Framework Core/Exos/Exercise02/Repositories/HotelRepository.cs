using Exercise02.Data;
using Exercise02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Exercise02.Repositories;

public class HotelRepository(ApplicationDbContext db) : IRepository<Hotel,int>
{
    public bool Add(Hotel obj)
    {
        EntityEntry<Hotel> entry = db.Add(obj);
        return db.SaveChanges()==1;
    }
    
    public Hotel? GetById(int id)
    {
        return db.Hotels
            .Include(h=>h.Rooms)
            .Include(h=>h.Bookings)
            .FirstOrDefault(h=>h.Id == id);
    }
    
    public Hotel? Get(Func<Hotel, bool> predicate)
    {
        return db.Hotels
        .Include(h=>h.Rooms)
        .Include(h=>h.Bookings)
        .FirstOrDefault(predicate);
    }
    
    public IEnumerable<Hotel> GetAll()=>db.Hotels;
    
    public IEnumerable<Hotel> GetAll(Func<Hotel, bool> predicate)=>db.Hotels.Where(predicate);
    
    public bool Delete(int id)
    {
        var hotel = GetById(id);
        if (hotel != null)
            return false;
        db.Hotels.Remove(hotel);
        return Save();
    }
    
    public bool Save()=>db.SaveChanges()>0;
}