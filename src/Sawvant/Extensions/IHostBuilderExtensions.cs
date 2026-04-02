/*
 * Sawvant Cutting Optimization API — .NET SDK
 *
 * File generated from our OpenAPI spec; DO NOT EDIT.
 */

#nullable enable

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sawvant.Client;

namespace Sawvant.Extensions
{
    /// <summary>
    /// Extension methods for IHostBuilder
    /// </summary>
    public static class IHostBuilderExtensions
    {
        /// <summary>
        /// Add the api to your host builder.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="options"></param>
        public static IHostBuilder ConfigureApi(this IHostBuilder builder, Action<HostBuilderContext, IServiceCollection, HostConfiguration> options)
        {
            builder.ConfigureServices((context, services) => 
            {
                HostConfiguration config = new HostConfiguration(services);

                options(context, services, config);

                IServiceCollectionExtensions.AddApi(services, config);
            });

            return builder;
        }
    }
}
