using HotelReservation.Domain;

namespace HotelReservation.Application;
public class EmailConfirmationHandler : IReservationEventHandler
{
    public void Handle(ReservationCreatedEvent evt)
    {
        Console.WriteLine($"[EMAIL] Confirmation sent to {evt.Email}");
    }
}
