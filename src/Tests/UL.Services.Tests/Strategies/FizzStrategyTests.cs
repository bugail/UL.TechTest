// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzStrategyTests.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.Services.Tests.Strategies
{
    using FluentAssertions;
    using Microsoft.Extensions.Logging;
    using NSubstitute;
    using NUnit.Framework;
    using UL.Core.Constants;
    using Ul.Services.Strategies;

    [TestFixture]
    public class FizzStrategyTests
    {
        private FizzStrategy target;

        [SetUp]
        public void Setup()
        {
            this.target = new FizzStrategy();
        }

        [TestCase(1, "")]
        [TestCase(3, OutputConstants.FizzMessage)]
        [TestCase(5, "")]
        [TestCase(15, OutputConstants.FizzMessage)]
        [TestCase(27, OutputConstants.FizzMessage)]
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