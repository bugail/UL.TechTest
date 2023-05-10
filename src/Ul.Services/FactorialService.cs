// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FactorialService.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.Services
{
    using UL.Abstractions.Interfaces;
    using UL.Core.Extensions;

    /// <summary>
    /// The factorial service.
    /// </summary>
    public class FactorialService : IFactorialService
    {
        /// <inheritdoc />
        public int Calculate(int value)
        {
            return value.Factorial();
        }
    }
}