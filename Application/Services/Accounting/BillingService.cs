namespace HotelReservation.Application.Services.Accounting;
public class BillingService 
{
    private readonly IReservationBilling _billing;

    public BillingService(IReservationBilling billing)
    {
        _billing = billing;
    }

    public decimal GetRevenueForPeriod(DateTime from, DateTime to)
    {
        return _billing.GetTotalRevenue(from, to);
    }
}
