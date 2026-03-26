using HotelReservation.Domain;

namespace HotelReservation.Application;
public interface IReservationRepository
{
    Reservation? GetById(string id);
    List<Reservation> GetAll();
    List<Reservation> GetByDateRange(DateTime from, DateTime to);
    List<Reservation> GetByGuest(string guestName);
    void Add(Reservation reservation);
    void Update(Reservation reservation);
    void Delete(string id);
    decimal GetTotalRevenue(DateTime from, DateTime to);
    Dictionary<string, int> GetOccupancyStats(DateTime from, DateTime to);
}
