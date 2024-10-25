// ------------------------------------------------------------------------------------------
//  <copyright file = "IntervalVerification.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.Api.Verify;
using Anexia.Validation.Interval.Common;
using Anexia.Validation.Interval.Exception;
#endregion

namespace Anexia.Validation.Interval.Verify;

public sealed class IntervalVerification<T> : IReusableVerification<T>
    where T : IComparable<T>
{
    private readonly ReusableVerification<T> _verification;

    private IntervalVerification(ReusableVerification<T> verification)
    {
        _verification = verification;
    }

    public IntervalVerification(IInterval<T> interval)
        : this(
            new ReusableVerification<T>(
                interval.Contains,
                value => new ValueOutOfIntervalException<T>(value, interval)))
    { }

    public IntervalVerification(IInterval<T> interval, Func<T, System.Exception> exceptionSupplier)
        : this(new ReusableVerification<T>(interval.Contains, exceptionSupplier))
    { }

    public T Verify(T value) => _verification.Verify(value);
}