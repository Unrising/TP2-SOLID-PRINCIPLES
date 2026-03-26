namespace HotelReservation.Application;
public interface INotificationServiceEmail
{
    void Send(string to, string subject, string body);
}
