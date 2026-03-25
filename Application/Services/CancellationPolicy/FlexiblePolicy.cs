namespace HotelReservation.Application;

using HotelReservation.Application.Services.Reservation;
using HotelReservation.Domain.Models;

public class FlexiblePolicy : ICancellationPolicy
{
    public decimal CalculateRefund(Reservation reservation, DateTime now)
    {
        var daysBeforeCheckIn = (reservation.CheckIn - now).Days;
        return daysBeforeCheckIn >= 1 ? reservation.TotalPrice : 0m;
    }
}
