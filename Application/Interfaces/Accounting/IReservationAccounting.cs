using HotelReservation.Domain;

namespace HotelReservation.Application;
public interface IReservationAccounting
{
    decimal Calculate(Reservation reservation);
    string GenerateInvoiceLine(Reservation reservation);
}
