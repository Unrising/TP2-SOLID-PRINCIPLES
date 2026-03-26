using HotelReservation.Application;

namespace HotelReservation.Infrastructure;
public class NotificationServiceSlack : INotificationServiceSlack
{
    public void Send(string channel, string message)
    {
        Console.WriteLine($"[SLACK] {message} sent to #{channel}");
    }
}
