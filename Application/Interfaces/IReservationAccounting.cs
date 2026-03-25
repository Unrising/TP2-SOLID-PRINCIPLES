using HotelReservation.Domain.Models;

namespace HotelReservation.Application.Interfaces
{
    public interface IReservationAccounting
    {
        decimal Calculate(Reservation reservation);
        string GenerateInvoiceLine(Reservation reservation);
    }
}
