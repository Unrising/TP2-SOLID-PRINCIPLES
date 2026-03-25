using HotelReservation.Application.Interfaces;

namespace HotelReservation.Application.Services.Billing;

public class SeasonalSurchargeDecorator : IPriceCalculator
{
    private readonly IPriceCalculator _inner;
    private readonly decimal _surchargeRate;

    public SeasonalSurchargeDecorator(IPriceCalculator inner, decimal surchargeRate)
    {
        _inner = inner;
        _surchargeRate = surchargeRate;
    }

    public decimal Calculate(Domain.Models.Reservation reservation)
    {
        var basePrice = _inner.Calculate(reservation);
        return basePrice * (1 + _surchargeRate);
    }

}
