using HotelReservation.Domain;

namespace HotelReservation.Application;
public interface ICheckIn
{
    public void ProcessCheckIn(Reservation reservation);
    public void ProcessCheckOut(Reservation reservation);

}
