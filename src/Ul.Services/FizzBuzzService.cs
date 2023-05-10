// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="FizzBuzzService.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Ardalis.GuardClauses;
    using FluentValidation;
    using Microsoft.Extensions.Logging;
    using UL.Abstractions.Interfaces;
    using UL.Core.Requests;
    using UL.Core.Validators;

    /// <summary>
    /// The fizzbuzz service.
    /// </summary>
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IEnumerable<IFizzBuzzStrategy> strategies;
        private readonly ILogger<FizzBuzzService> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzService"/> class.
        /// </summary>
        /// <param name="strategies">A list of <see cref="IFizzBuzzStrategy"/></param>
        /// <param name="logger">The logger.</param>
        public FizzBuzzService(IEnumerable<IFizzBuzzStrategy> strategies, ILogger<FizzBuzzService> logger)
        {
            this.strategies = strategies;
            this.logger = logger;
        }

        /// <inheritdoc />
        public IEnumerable<string> GetFizzBuzzList(IEnumerable<int> collection)
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

        /// <inheritdoc />
        public IEnumerable<string> GetFizzBuzzList(FizzBuzzRequest request)
        {
            Guard.Against.Null(request, nameof(request));

            var validator = new FizzBuzzRequestValidator();
            var result = validator.Validate(request);

            if (result.IsValid)
            {
                var list = Enumerable.Range(Convert.ToInt32(request.Start), Convert.ToInt32(request.End)).ToList();
                return this.GetFizzBuzzList(list);
            }

            throw new ValidationException(result.ToString());
        }
    }
}