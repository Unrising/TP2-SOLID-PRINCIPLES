using HotelReservation.Application;

namespace HotelReservation.Infrastructure;
public class NotificationServiceEmail : INotificationServiceEmail
{
    public void Send(string to, string subject, string body)
    {
        Console.WriteLine($"[EMAIL] {subject} sent to {to}");
    }
}
