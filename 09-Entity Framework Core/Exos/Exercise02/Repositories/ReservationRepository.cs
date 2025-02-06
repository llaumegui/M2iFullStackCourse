using Exercise02.Data;
using Exercise02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Exercise02.Repositories;

public class ReservationRepository(ApplicationDbContext db) : IRepository<Booking, int>
{
    public bool Add(Booking obj)
    {
        EntityEntry<Booking> entry = db.Add(obj);
        return db.SaveChanges()==1;
    }
    
    public Booking? GetById(int id)
    {
        return db.Bookings
            .Include(r => r.Rooms)
            .FirstOrDefault(r=>r.Id==id);
    }
    
    public Booking? Get(Func<Booking, bool> predicate)
    {
        return db.Bookings
            .Include(r => r.Rooms)
            .Include(r=>r.Client)
            .FirstOrDefault(predicate);
    }
    
    public IEnumerable<Booking> GetAll()
    {
        return db.Bookings;
    }
    
    public IEnumerable<Booking> GetAll(Func<Booking, bool> predicate)
    {
        return db.Bookings.Where(predicate);
    }
    
    public bool Delete(int id)
    {
        var reservation = GetById(id);
        if (reservation == null)
        return false;
        
        db.Bookings.Remove(reservation);
        return Save();
    }

    public bool Save()=>db.SaveChanges()>0;
}