// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IFactorialService.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.Abstractions.Interfaces
{
    /// <summary>
    /// The factorial service interface.
    /// </summary>
    public interface IFactorialService
    {
        /// <summary>
        /// Calculates the factoral.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A <see cref="int"/>.</returns>
        int Calculate(int value);
    }
}