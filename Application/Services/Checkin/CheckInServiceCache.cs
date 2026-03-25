using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Models;
using HotelReservation.Infrastructure;

public class CheckInServiceCache(ICheckIn checkIn, ILogger logger) : ICheckIn
{
    private readonly Dictionary<string, CacheEntry> _cache = new();
    public void ProcessCheckIn(Reservation reservation)
    {
        if (_cache.ContainsKey(reservation.Id))
            _cache.Remove(reservation.Id);
        _cache[reservation.Id] = new CacheEntry(DateTime.Now, "CheckedIn");

        checkIn.ProcessCheckIn(reservation);

        logger.Log($"[SMS] Room {reservation.RoomId} is now occupied");
    }

    public void ProcessCheckOut(Reservation reservation)
    {
        checkIn.ProcessCheckOut(reservation);

        if (_cache.ContainsKey(reservation.Id))
            _cache.Remove(reservation.Id);

        logger.Log($"[SMS] Room {reservation.RoomId} is now free");
    }
}
