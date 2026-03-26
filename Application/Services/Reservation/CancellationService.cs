using HotelReservation.Domain;

namespace HotelReservation.Application;
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
