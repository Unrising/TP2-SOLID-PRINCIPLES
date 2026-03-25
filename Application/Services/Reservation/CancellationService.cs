namespace HotelReservation.Application.Services.Reservation;

using HotelReservation.Application.Interfaces;
using HotelReservation.Domain.Models;
using Microsoft.VisualBasic;

// OCP VIOLATION: Adding a new cancellation policy (e.g., "SuperFlexible")
// requires opening this class and adding a new case to the switch.
public class CancellationService(ICancellable cancellable)
{
    public void CancelReservation(Reservation reservation, DateTime now)
    {
        var refund = reservation.CalculateRefund(now);

        cancellable.Cancel();

        Console.WriteLine(
            $"[OK] Reservation {reservation.Id} cancelled (refund: {refund:F2} EUR)");
    }
}
public interface ICancellationPolicy
{
    decimal CalculateRefund(Reservation reservation, DateTime now);
}

public enum CancellationPolicyType
{
    Flexible,
    Moderate,
    Strict,
    NonRefundable
}
