// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FactoralServiceTests.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.Services.Tests
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class FactoralServiceTests
    {
        private FactorialService target;

        [SetUp]
        public void Setup()
        {
            this.target = new FactorialService();
        }

        [TestCase(3, 6)]
        public void Test(int value, int expectedResult)
        {
            // Act
            var result = this.target.Calculate(value);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}