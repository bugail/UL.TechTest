// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ServiceCollectionExtensions.cs" company="Bugail Consulting Ltd">
//      Copyright 2023 (c) Bugail Consulting Ltd. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

namespace UL.UI.Web
{
    using System;
    using System.IO;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Serilog;
    using Serilog.Extensions.Logging;
    using UL.Services.Extensions;

    /// <summary>
    /// Main program
    /// </summary>
    public partial class Program
    {
        private static ILogger<Program> startUpLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Program"/> class.
        /// </summary>
        protected Program()
        {
        }

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Command line args</param>
        /// <returns>Error code</returns>
        public static int Main(string[] args)
        {
            // Setup serilog static logger
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(GetLoggerConfiguration())
                .WriteTo.Debug()
                .CreateLogger();

            // Create a Microsoft.Extensions.Logging.ILoggerFactory from the serilog static logger
            var loggerFactory = new SerilogLoggerFactory(Log.Logger);
            startUpLogger = loggerFactory.CreateLogger<Program>();

            try
            {
                Log.Information("Starting Account Service Web");
                var app = CreateWebApplication(args);
                app.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IConfiguration GetLoggerConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("loggingSettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        private static WebApplication CreateWebApplication(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Host
                .UseSerilog((hostingContext, loggerConfiguration) =>
                    {
                        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
                            .Enrich.FromLogContext()
                            .Enrich.WithProperty(nameof(hostingContext.HostingEnvironment.EnvironmentName), hostingContext.HostingEnvironment.EnvironmentName);
                    })
                .ConfigureServices(services => ConfigureServices(services, builder));

            var app = BuildWebApplication(builder);
            return app;
        }


        private static void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddServices();
            services.AddRazorPages();
        }

        private static WebApplication BuildWebApplication(WebApplicationBuilder builder)
        {
            var app = builder.Build();

            app.UseStatusCodePagesWithReExecute("/Home/StatusCodeError", "?statusCode={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.MapRazorPages();

            return app;
        }
    }
}