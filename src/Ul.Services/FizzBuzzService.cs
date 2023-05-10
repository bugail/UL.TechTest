// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzBuzzService.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.Services
{
    using System.Collections.Generic;
    using System.Text;
    using Ardalis.GuardClauses;
    using Microsoft.Extensions.Logging;
    using UL.Abstractions.Interfaces;

    /// <summary>
    /// The fizzbuzz service.
    /// </summary>
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IEnumerable<IFizzBuzzStrategy> strategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzService"/> class.
        /// </summary>
        /// <param name="strategies">A list of <see cref="IFizzBuzzStrategy"/></param>
        public FizzBuzzService(IEnumerable<IFizzBuzzStrategy> strategies)
        {
            this.strategies = strategies;
        }

        /// <summary>
        /// Gets the fizzbuzz list of results.
        /// </summary>
        /// <param name="collection">The collection of numbers to check.</param>
        /// <returns>A List of <see cref="string"/>.</returns>
        public IList<string> GetFizzBuzzList(IEnumerable<int> collection)
        {
            Guard.Against.NullOrEmpty(collection, nameof(collection));

            var list = new List<string>();
            var value = string.Empty;

            foreach (var item in collection)
            {
                var builder = new StringBuilder();

                foreach (var strategy in strategies)
                {
                    builder.Append(strategy.Execute(item));
                }

                value = builder.ToString();

                list.Add(value == string.Empty ? item.ToString() : value);
            }

            return list;
        }
    }
}