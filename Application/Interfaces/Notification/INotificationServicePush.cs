namespace HotelReservation.Application;
public interface INotificationServicePush
{
    void Send(string deviceId, string message);
}
