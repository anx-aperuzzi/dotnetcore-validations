// --------------------------------------------------------------------------------------------
//  <copyright file = "LeftClosedRightOpenIntervalTest.cs" company = "ANEXIA® Internetdienstleistungs GmbH">
//  Copyright (c) ANEXIA® Internetdienstleistungs GmbH.All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------

#region

using ANX.Common.Validation.Interval.Closed;
using Xunit;
using static Xunit.Assert;

#endregion

namespace ANX.Common.Validation.IntervalTesting.Closed;

public sealed class LeftClosedRightOpenIntervalTest {
    private static readonly LeftClosedRightOpenInterval<int> _interval = new(-5, 5);

    [Theory]
    [InlineData(-6, false)]
    [InlineData(-5, true)]
    [InlineData(0, true)]
    [InlineData(5, false)]
    [InlineData(6, false)]
    public void ContainsReturnsCorrectResult(int value, bool expectedResult) =>
        Equal(expectedResult, _interval.Contains(value));
}