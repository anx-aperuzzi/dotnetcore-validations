// ------------------------------------------------------------------------------------------
//  <copyright file = "OpenIntervalTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH. All rights reserved.
//  </copyright>
// ------------------------------------------------------------------------------------------

#region
using Anexia.Validation.Interval.Open;
using static Xunit.Assert;
#endregion

namespace Anexia.Validation.IntervalTesting.Open;

public sealed class OpenIntervalTest
{
    private static readonly OpenInterval<int> _interval = new(-5, 5);

    [Theory]
    [InlineData(-6, false)]
    [InlineData(-5, false)]
    [InlineData(0, true)]
    [InlineData(5, false)]
    [InlineData(6, false)]
    public void ContainsReturnsCorrectResult(int value, bool expectedResult) =>
        Equal(expectedResult, _interval.Contains(value));
}