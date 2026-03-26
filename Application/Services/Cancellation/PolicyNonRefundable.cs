using HotelReservation.Domain;

namespace HotelReservation.Application;
public class PolicyNonRefundable : ICancellationPolicy
{
    public decimal CalculateRefund(Reservation reservation, DateTime now)
    {
        return 0m;
    }
}