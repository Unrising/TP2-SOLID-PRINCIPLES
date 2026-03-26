namespace HotelReservation.Application;
public interface INotificationServiceSlack
{
    void Send(string channel, string message);
}

