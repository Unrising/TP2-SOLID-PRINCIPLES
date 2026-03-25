using HotelReservation.Application.Services.Reservation;

namespace HotelReservation.Application;

public static class CancellationPolicyFactory
{
    public static ICancellationPolicy Create(CancellationPolicyType type)
    {
        return type switch
        {
            CancellationPolicyType.Flexible => new FlexiblePolicy(),
            CancellationPolicyType.Moderate => new ModeratePolicy(),
            CancellationPolicyType.Strict => new StrictPolicy(),
            CancellationPolicyType.NonRefundable => new NonRefundablePolicy(),
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };
    }
}
