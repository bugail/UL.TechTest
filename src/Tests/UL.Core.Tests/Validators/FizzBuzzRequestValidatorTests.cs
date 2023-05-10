// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzBuzzRequestValidatorTests.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.Core.Tests.Validators
{
    using Bogus;
    using FluentValidation.TestHelper;
    using NUnit.Framework;
    using UL.Core.Requests;
    using UL.Core.Validators;

    public class FizzBuzzRequestValidatorTests
    {
        private FizzBuzzRequestValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new FizzBuzzRequestValidator();
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("12x")]
        public void Validate_InvalidStart_HasErrors(string value)
        {
            // Arrange
            var model = new FizzBuzzRequest(value, string.Empty);

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(person => person.Start);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("12x")]
        [TestCase("0")]
        public void Validate_InvalidEnd_HasErrors(string value)
        {
            // Arrange
            var model = new FizzBuzzRequest(string.Empty, value);

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(person => person.End);
        }
    }
}