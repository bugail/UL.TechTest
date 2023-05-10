// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzBuzzServiceTests.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Microsoft.Extensions.Logging;
    using NSubstitute;
    using NUnit.Framework;
    using UL.Abstractions.Interfaces;
    using Ul.Services.Strategies;

    [TestFixture]
    public class FizzBuzzServiceTests
    {
        private List<IFizzBuzzStrategy> stategies;
        private FizzBuzzService target;

        [SetUp]
        public void Setup()
        {
            this.stategies = new List<IFizzBuzzStrategy>
            {
                new FizzStrategy(),
                new BuzzStrategy()
            };

            this.target = new FizzBuzzService(this.stategies);
        }

        [Test]
        public void GetFizzBuzzList_ValidCollection_ReturnsValidResults()
        {
            // Arrange
            var list = Enumerable.Range(1, 100).ToList();

            // Act
            var results = this.target.GetFizzBuzzList(list);

            // Assert
            results.ToList().Count.Should().Be(100);
        }

        [Test]
        public void GetFizzBuzzList_NullCollection_ThrowsException()
        {
            // Arrange
            List<int> collection = null;

            // Act
            Func<IEnumerable<string>> action = () => this.target.GetFizzBuzzList(collection);

            // Assert
            action.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("*collection*");
        }

        [Test]
        public void GetFizzBuzzList_EmptyCollection_ThrowsException()
        {
            // Arrange
            List<int> collection = new List<int>();

            // Act
            Func<IEnumerable<string>> action = () => this.target.GetFizzBuzzList(collection);

            // Assert
            action.Should()
                .Throw<ArgumentException>()
                .WithMessage("*collection*");
        }
    }
}