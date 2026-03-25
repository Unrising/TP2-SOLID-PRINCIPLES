namespace HotelReservation.Application.Services;

using HotelReservation.Domain.Models;
using HotelReservation.Infrastructure.Services;

// DIP VIOLATION (Example 2): High-level housekeeping logic directly depends on
// low-level EmailSender. If we want to notify by SMS instead, we must modify this class.
public class HousekeepingService
{
    // Direct dependency on concrete EmailSender
    private readonly EmailSender _emailSender = new();



    public List<CleaningTask> GenerateLinenChangeSchedule(Reservation reservation)
    {
        var tasks = new List<CleaningTask>();
        var current = reservation.CheckIn.AddDays(3);
        while (current < reservation.CheckOut)
        {
            tasks.Add(new CleaningTask
            {
                RoomId = reservation.RoomId,
                Date = current,
                Type = "LinenChange",
                HousekeeperEmail = "housekeeping@masdesoliviers.fr",
                Time = new TimeSpan(10, 0, 0)
            });
            current = current.AddDays(3);
        }
        return tasks;
    }
    public List<DateTime> GetLinenChangeDays(Reservation reservation)
    {
        var days = new List<DateTime>();
        var current = reservation.CheckIn.AddDays(3);
        while (current < reservation.CheckOut)
        {
            days.Add(current);
            current = current.AddDays(3);
        }
        return days;
    }
    public void NotifyHousekeeper(CleaningTask task)
    {
        // Coupled to email — can't switch to SMS without changing this code
        _emailSender.Send(
            task.HousekeeperEmail,
            "New cleaning task",
            $"Room {task.RoomId} needs {task.Type} on {task.Date:dd/MM/yyyy}");
    }
}
