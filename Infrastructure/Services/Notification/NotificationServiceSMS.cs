using HotelReservation.Application;

namespace HotelReservation.Infrastructure;
public class NotificationServiceSMS : INotificationServiceSMS
{
    public void Send(string phoneNumber, string message)
    {
        Console.WriteLine($"[SMS] {message} sent to {phoneNumber}");
    }
}
