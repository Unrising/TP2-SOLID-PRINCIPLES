namespace HotelReservation.Application;
public interface INotificationServiceSMS
{
    void Send(string phoneNumber, string message);
}
