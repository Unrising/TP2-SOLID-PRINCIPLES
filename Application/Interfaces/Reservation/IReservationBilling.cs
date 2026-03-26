namespace HotelReservation.Application;
public interface IReservationBilling
{
    decimal GetTotalRevenue(DateTime from, DateTime to);
}

