using HotelReservation.Domain.Models;

namespace HotelReservation.Application.Interfaces
{
    public interface ICheckIn
    {
        public void ProcessCheckIn(Reservation reservation);
        public void ProcessCheckOut(Reservation reservation);

    }
}
