using HotelReservation.Domain;

namespace HotelReservation.Application;
public interface ICancellationPolicy
{
    decimal CalculateRefund(Reservation reservation, DateTime now);
}
