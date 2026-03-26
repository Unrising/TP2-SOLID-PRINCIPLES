using HotelReservation.Application;

namespace HotelReservation.Infrastructure;
public class NotificationServicePush : INotificationServicePush
{
    public void Send(string deviceId, string message)
    {
        Console.WriteLine($"[PUSH] {message} sent to device {deviceId}");
    }
}
