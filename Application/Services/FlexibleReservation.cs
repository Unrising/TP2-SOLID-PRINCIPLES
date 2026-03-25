using HotelReservation.Application.Interfaces;

namespace HotelReservation.Application.Services;

public class FlexibleReservation : ICancellable
{
    public string Id { get; set; } = string.Empty;
    public string GuestName { get; set; } = string.Empty;
    public string Status { get; set; } = "Confirmed";
    public decimal TotalPrice { get; set; }

    public void Cancel()
    {
        if (Status == "CheckedIn")
            throw new InvalidOperationException("Cannot cancel after check-in");
        Status = "Cancelled";
    }

    public decimal CalculateRefund()
    {
        return TotalPrice; // Full refund
    }
}
