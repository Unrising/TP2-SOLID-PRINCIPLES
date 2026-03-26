using HotelReservation.Domain;

namespace HotelReservation.Application;
public class HousekeepingService(INotificationServiceEmail _notification)
{
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
        _notification.Send(
            task.HousekeeperEmail,
            "New cleaning task",
            $"Room {task.RoomId} needs {task.Type} on {task.Date:dd/MM/yyyy}");
    }
}
