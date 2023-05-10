// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BuzzStrategyTests.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.Services.Tests.Strategies
{
    using FluentAssertions;
    using NUnit.Framework;
    using UL.Core.Constants;
    using Ul.Services.Strategies;

    [TestFixture]
    public class BuzzStrategyTests
    {
        private BuzzStrategy target;

        [SetUp]
        public void Setup()
        {
            this.target = new BuzzStrategy();
        }

        [TestCase(1, "")]
        [TestCase(3, "")]
        [TestCase(5, OutputConstants.BuzzMessage)]
        [TestCase(15, OutputConstants.BuzzMessage)]
        [TestCase(27, "")]
        public void Execute_ValidValue_ReturnsCorrectResult(int value, string expectedResult)
        {
            // Arrange

            // Act
            var result = this.target.Execute(value);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}