namespace HotelReservation.Application;

using HotelReservation.Domain;
public class PolicyFlexible : ICancellationPolicy
{
    public decimal CalculateRefund(Reservation reservation, DateTime now)
    {
        var daysBeforeCheckIn = (reservation.CheckIn - now).Days;
        return daysBeforeCheckIn >= 1 ? reservation.TotalPrice : 0m;
    }
}
