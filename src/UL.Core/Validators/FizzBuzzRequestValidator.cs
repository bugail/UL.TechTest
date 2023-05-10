// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzBuzzRequestValidator.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.Core.Validators
{
    using FluentValidation;
    using UL.Core.Extensions;
    using UL.Core.Requests;

    /// <summary>
    /// The fizz buzz validator.
    /// </summary>
    public class FizzBuzzRequestValidator : AbstractValidator<FizzBuzzRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzRequestValidator"/> class.
        /// </summary>
        public FizzBuzzRequestValidator()
        {
            this.RuleFor(x => x.Start)
                .NotEmpty()
                .NotNull()
                .Must(x => x.IsNumeric()).WithMessage("Start must be a valid number");

            this.RuleFor(x => x.End)
                .NotEmpty()
                .NotNull()
                .Must(x => x.IsNumeric()).WithMessage("End must be a valid number")
                .Custom((x, context) =>
                {
                    if (!int.TryParse(x, out int value) || value <= 0)
                    {
                        context.AddFailure($"End must be greater than 0.");
                    }
                });
        }
    }
}