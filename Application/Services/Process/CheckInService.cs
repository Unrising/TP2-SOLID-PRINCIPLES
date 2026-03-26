using HotelReservation.Domain;

namespace HotelReservation.Application;

public class CheckInService : ICheckIn
{
    private readonly IReservationRepository _dataStore;

    public CheckInService(IReservationRepository reservationRepo)
    {
        _dataStore = reservationRepo;

    }
    public void ProcessCheckIn(Reservation reservation)
    {
        if (reservation.Status != "Confirmed")
            throw new Exception($"Cannot check in: reservation is {reservation.Status}");

        var lateCheckInFee = 25m; 
        if (DateTime.Now.Hour >= 22)
            reservation.TotalPrice += lateCheckInFee;

        reservation.Status = "CheckedIn";
    }
    public void ProcessCheckOut(Reservation reservation)
    {
        if (reservation.Status != "CheckedIn")
            throw new Exception($"Cannot check out: reservation is {reservation.Status}");

        reservation.Status = "CheckedOut";
    }
}