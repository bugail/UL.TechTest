// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BuzzStrategy.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace Ul.Services.Strategies
{
    using Microsoft.Extensions.Logging;
    using UL.Core.Constants;
    using UL.Core.Extensions;

    /// <summary>
    /// The buzz strategy.
    /// </summary>
    public class BuzzStrategy : BaseStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuzzStrategy"/> class.
        /// </summary>
        public BuzzStrategy()
            : base(
                i => i.IsDivisableBy(5),
                OutputConstants.BuzzMessage)
        {
        }
    }
}