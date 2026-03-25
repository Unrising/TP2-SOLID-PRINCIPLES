using HotelReservation.Application.Services.Reservation;

namespace HotelReservation.Domain.Models;

public class Reservation
{
    public string Id { get; set; } = string.Empty;
    public string GuestName { get; set; } = string.Empty;
    public string RoomId { get; set; } = string.Empty;
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int GuestCount { get; set; }
    public string RoomType { get; set; } = string.Empty;
    public string Status { get; set; } = "Confirmed"; // Confirmed, CheckedIn, CheckedOut, Cancelled
    public ICancellationPolicy CancellationPolicy { get; set; }
    public string Email { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public decimal CalculateRefund(DateTime now)
    {
        return CancellationPolicy.CalculateRefund(this, now);
    }
}
