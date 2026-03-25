namespace HotelReservation.Application.Services;

using HotelReservation.Infrastructure;
using HotelReservation.Domain.Models;
using HotelReservation.Infrastructure.Interfaces;

public class ReservationService
{
    private readonly ILogger _logger;
    private readonly IReservationRepository _reservationRepo;
    private readonly IRoomRepository _roomRepo;
    public ReservationService(ILogger logger, IReservationRepository reservationRepo, IRoomRepository roomRepo)
    {
        _logger = logger;
        _reservationRepo = reservationRepo;
        _roomRepo = roomRepo;
    }

    private static int _counter = 0;

    public string CreateReservation(string guestName, string roomId, DateTime checkIn,
        DateTime checkOut, int guestCount, string roomType, string email)
    {
        _logger.Log($"Creating reservation for {guestName}...");

        List<Room> _rooms = _roomRepo.GetAvailableRooms(checkIn, checkOut);

        Room? room = _rooms.FirstOrDefault(r => r.Id == roomId);

        if(room is null)
            throw new Exception($"Room {roomId} not found");

        room.Validate(guestCount, room, roomId);

        var nights = (checkOut - checkIn).Days;

        var totalPrice = room.GetPricePerNight(nights, room);

        _counter++;
        var reservation = new Reservation
        {
            Id = $"R-{_counter:D3}",
            GuestName = guestName,
            RoomId = roomId,
            CheckIn = checkIn,
            CheckOut = checkOut,
            GuestCount = guestCount,
            RoomType = roomType,
            Status = "Confirmed",
            Email = email,
            TotalPrice = totalPrice
        };

        _reservationRepo.Add(reservation);

        _logger.Log($"Reservation {reservation.Id} created.");

        return reservation.Id;
    }

    public Reservation? GetReservation(string id)
    {
        return _reservationRepo.GetById(id);
    }

    public List<Reservation> GetAllReservations()
    {
        return _reservationRepo.GetAll();
    }
}
