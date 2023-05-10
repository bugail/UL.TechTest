// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WizzStrategy.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Ul.Services.Strategies
{
    using Microsoft.Extensions.Logging;
    using UL.Core.Constants;
    using UL.Core.Extensions;

    /// <summary>
    /// The wizz strategy. Used to show possible extensions to FizzBuzz logic.
    /// </summary>
    public class WizzStrategy : BaseStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WizzStrategy"/> class.
        /// </summary>
        public WizzStrategy()
            : base(
                i => i == 100,
                OutputConstants.WizzMessage)
        {
        }
    }
}