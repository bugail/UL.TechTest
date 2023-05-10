// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzStrategy.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Ul.Services.Strategies
{
    using Microsoft.Extensions.Logging;
    using UL.Core.Constants;
    using UL.Core.Extensions;

    /// <summary>
    /// The fizz strategy.
    /// </summary>
    public class FizzStrategy : BaseStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FizzStrategy"/> class.
        /// </summary>
        public FizzStrategy()
            : base(
                i => i.IsDivisableBy(3),
                OutputConstants.FizzMessage)
        {
        }
    }
}