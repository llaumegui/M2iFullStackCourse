using Exercise02.Data;
using Exercise02.Models;
using Exercise02.Repositories;

namespace Exercise02.Classes;

public class AppController(Display display)
{
    private Display _display = display;
    private Hotel _hotel = new();

    #region Repositories
    private ClientRepository _clientRepository = new(new ApplicationDbContext());
    private RoomRepository _roomRepository = new(new ApplicationDbContext());
    private ReservationRepository _reservationRepository = new(new ApplicationDbContext());
    private HotelRepository _hotelRepository = new(new ApplicationDbContext());
    #endregion
    
    public void CreateNewHotel()
    {
        _hotel.Name = _display.GetInput("Entrer le nom de l'hotel: ");
        _hotelRepository.Add(_hotel);
    }
    
    public void AddClient()
    {
        Client client = new();
        client.LastName = _display.GetInput("Entrer le nom du client: ");
        client.FirstName = _display.GetInput("Entrer le prénom du client: ");
        client.PhoneNumber = _display.GetInput("Entrer le numéro de téléphone du client: ");
        _clientRepository.Add(client);
    }

    public void ShowClientList()
    {
        var clients = _clientRepository.GetAll();
        foreach (var client in clients)
            _display.ShowOutput(client.ToString());
    }

    public void ShowClientBookings()
    {
        int clientId = int.Parse(_display.GetInput("Sélectionner l'id du client: "));
        var client = _clientRepository.GetById(clientId);
        if (client == null)
        {
            _display.ShowOutput("Ce client n'existe pas");
            return;
        }
        foreach (var booking in client.Bookings)
        {
            _display.ShowOutput(booking.ToString());
        }
    }

    public void AddBooking()
    {        
        int clientId = int.Parse(_display.GetInput("Sélectionner l'id du client: "));
        var client = _clientRepository.GetById(clientId);
        if (client == null)
        {
            _display.ShowOutput("Ce client n'existe pas");
            return;
        }
        //TODO faire le reste
    }

    public void CancelBooking()
    {
        throw new NotImplementedException();
    }

    public void ShowBookingsList()
    {
        throw new NotImplementedException();
    }
}