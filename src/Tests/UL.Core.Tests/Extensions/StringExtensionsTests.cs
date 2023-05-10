// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="StringExtensionsTests.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.Core.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using UL.Core.Extensions;

    [TestFixture]
    public class StringExtensionsTests
    {
        [TestCase("", true)]
        public void IsNumeric_ValidString_ReturnsCorrectResult(string value, bool expectedResult)
        {
            // Act
            var result = value.IsNumeric();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}