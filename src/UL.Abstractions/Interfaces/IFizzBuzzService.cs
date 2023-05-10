// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IFizzBuzzService.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.Abstractions.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The fizz buzz service interface.
    /// </summary>
    public interface IFizzBuzzService
    {
        /// <summary>
        /// Gets the list of FizzBuzz values.
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <returns>A list of <see cref="string"/>.</returns>
        IList<string> GetFizzBuzzList(IEnumerable<int> collection);
    }
}