using HotelReservation.Domain;

namespace HotelReservation.Application;

public interface IReservationEventHandler
{
    void Handle(ReservationCreatedEvent evt);
}
