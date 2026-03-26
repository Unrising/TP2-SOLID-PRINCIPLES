using HotelReservation.Domain;

namespace HotelReservation.Application;
public static class CancellationPolicyFactory
{
    public static ICancellationPolicy Create(CancellationPolicyType type)
    {
        return type switch
        {
            CancellationPolicyType.Flexible => new PolicyFlexible(),
            CancellationPolicyType.Moderate => new PolicyModerate(),
            CancellationPolicyType.Strict => new PolicyStrict(),
            CancellationPolicyType.NonRefundable => new PolicyNonRefundable(),
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };
    }
}
