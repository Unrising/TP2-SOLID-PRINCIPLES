namespace HotelReservation.Domain;
public class Room
{
    public string Id { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // "Standard", "Suite", "Family"
    public int MaxGuests { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; } = true;
    public void Validate(int guestCount, Room room, string roomId)
    {
        if (guestCount > room.MaxGuests)
            throw new Exception($"Room {roomId} max capacity is {room.MaxGuests}");
    }
    public decimal GetPricePerNight(int nights, Room room)
    {
        return nights * room.PricePerNight;
    }
}
