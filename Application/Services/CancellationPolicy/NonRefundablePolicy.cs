namespace HotelReservation.Application;

using HotelReservation.Application.Services.Reservation;
using HotelReservation.Domain.Models;

public class NonRefundablePolicy : ICancellationPolicy
{
    public decimal CalculateRefund(Reservation reservation, DateTime now)
    {
        return 0m;
    }
}