namespace HotelReservation.Infrastructure;
public class FileLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}
