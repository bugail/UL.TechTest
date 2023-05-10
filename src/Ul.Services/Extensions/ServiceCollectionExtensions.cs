// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ServiceCollectionExtensions.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.Services.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using UL.Abstractions.Interfaces;
    using Ul.Services.Strategies;

    /// <summary>
    /// The service collection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>A <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddFactorialServices()
                .AddFizzBuzzServices();
        }

        private static IServiceCollection AddFizzBuzzServices(this IServiceCollection services)
        {
            services.AddTransient<IFizzBuzzStrategy, FizzStrategy>();
            services.AddTransient<IFizzBuzzStrategy, BuzzStrategy>();

            // Excluded to comply with requirements. FizzBuzz only.
            ////services.AddScoped<IStrategy, WizzStrategy>();

            services.AddTransient<IFizzBuzzService, FizzBuzzService>();

            return services;
        }

        private static IServiceCollection AddFactorialServices(this IServiceCollection services)
        {
            services.AddTransient<IFactorialService, FactorialService>();
            return services;
        }
    }
}