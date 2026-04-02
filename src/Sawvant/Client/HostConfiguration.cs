/*
 * Sawvant Cutting Optimization API — .NET SDK
 *
 * File generated from our OpenAPI spec; DO NOT EDIT.
 */

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Sawvant.Api;
using Sawvant.Model;

namespace Sawvant.Client
{
    /// <summary>
    /// Provides hosting configuration for Sawvant
    /// </summary>
    public class HostConfiguration
    {
        private readonly IServiceCollection _services;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions();

        internal bool HttpClientsAdded { get; private set; }

        /// <summary>
        /// Instantiates the class 
        /// </summary>
        /// <param name="services"></param>
        public HostConfiguration(IServiceCollection services)
        {
            _services = services;
            _jsonOptions.Converters.Add(new JsonStringEnumConverter());
            _jsonOptions.Converters.Add(new DateTimeJsonConverter());
            _jsonOptions.Converters.Add(new DateTimeNullableJsonConverter());
            _jsonOptions.Converters.Add(new DateOnlyJsonConverter());
            _jsonOptions.Converters.Add(new DateOnlyNullableJsonConverter());
            _jsonOptions.Converters.Add(new CostJsonConverter());
            _jsonOptions.Converters.Add(new CostTariffsJsonConverter());
            _jsonOptions.Converters.Add(new CutDirectionJsonConverter());
            _jsonOptions.Converters.Add(new CutDirectionNullableJsonConverter());
            _jsonOptions.Converters.Add(new EdgeCorrectionJsonConverter());
            _jsonOptions.Converters.Add(new ErrorJsonConverter());
            _jsonOptions.Converters.Add(new GrainDirectionJsonConverter());
            _jsonOptions.Converters.Add(new GrainDirectionNullableJsonConverter());
            _jsonOptions.Converters.Add(new HealthResponseJsonConverter());
            _jsonOptions.Converters.Add(new JobResponseJsonConverter());
            _jsonOptions.Converters.Add(new LayoutJsonConverter());
            _jsonOptions.Converters.Add(new MachineJsonConverter());
            _jsonOptions.Converters.Add(new MarginsJsonConverter());
            _jsonOptions.Converters.Add(new MetricsJsonConverter());
            _jsonOptions.Converters.Add(new OptimizeAcceptedJsonConverter());
            _jsonOptions.Converters.Add(new OptimizeRequestJsonConverter());
            _jsonOptions.Converters.Add(new OptimizeResultJsonConverter());
            _jsonOptions.Converters.Add(new PartJsonConverter());
            _jsonOptions.Converters.Add(new PlacementJsonConverter());
            _jsonOptions.Converters.Add(new RateLimitErrorJsonConverter());
            _jsonOptions.Converters.Add(new SheetJsonConverter());
            _jsonOptions.Converters.Add(new SheetUsageJsonConverter());
            _jsonOptions.Converters.Add(new SummaryJsonConverter());
            _jsonOptions.Converters.Add(new TierDefinitionJsonConverter());
            JsonSerializerOptionsProvider jsonSerializerOptionsProvider = new(_jsonOptions);
            _services.AddSingleton(jsonSerializerOptionsProvider);
            _services.AddSingleton<IApiFactory, ApiFactory>();
            _services.AddSingleton<JobsApiEvents>();
            _services.AddTransient<IJobsApi, JobsApi>();
            _services.AddSingleton<OptimizationApiEvents>();
            _services.AddTransient<IOptimizationApi, OptimizationApi>();
            _services.AddSingleton<SystemApiEvents>();
            _services.AddTransient<ISystemApi, SystemApi>();
        }

        /// <summary>
        /// Configures the HttpClients.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public HostConfiguration AddApiHttpClients
        (
            Action<HttpClient>? client = null, Action<IHttpClientBuilder>? builder = null)
        {
            if (client == null)
                client = c => c.BaseAddress = new Uri(ClientUtils.BASE_ADDRESS);

            List<IHttpClientBuilder> builders = new List<IHttpClientBuilder>();

            builders.Add(_services.AddHttpClient<IJobsApi, JobsApi>(client));
            builders.Add(_services.AddHttpClient<IOptimizationApi, OptimizationApi>(client));
            builders.Add(_services.AddHttpClient<ISystemApi, SystemApi>(client));
            
            if (builder != null)
                foreach (IHttpClientBuilder instance in builders)
                    builder(instance);

            HttpClientsAdded = true;

            return this;
        }

        /// <summary>
        /// Configures the JsonSerializerSettings
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public HostConfiguration ConfigureJsonOptions(Action<JsonSerializerOptions> options)
        {
            options(_jsonOptions);

            return this;
        }

        /// <summary>
        /// Adds tokens to your IServiceCollection
        /// </summary>
        /// <typeparam name="TTokenBase"></typeparam>
        /// <param name="token"></param>
        /// <returns></returns>
        public HostConfiguration AddTokens<TTokenBase>(TTokenBase token) where TTokenBase : TokenBase
        {
            return AddTokens(new TTokenBase[]{ token });
        }

        /// <summary>
        /// Adds tokens to your IServiceCollection
        /// </summary>
        /// <typeparam name="TTokenBase"></typeparam>
        /// <param name="tokens"></param>
        /// <returns></returns>
        public HostConfiguration AddTokens<TTokenBase>(IEnumerable<TTokenBase> tokens) where TTokenBase : TokenBase
        {
            TokenContainer<TTokenBase> container = new TokenContainer<TTokenBase>(tokens);
            _services.AddSingleton(services => container);

            return this;
        }

        /// <summary>
        /// Adds a token provider to your IServiceCollection
        /// </summary>
        /// <typeparam name="TTokenProvider"></typeparam>
        /// <typeparam name="TTokenBase"></typeparam>
        /// <returns></returns>
        public HostConfiguration UseProvider<TTokenProvider, TTokenBase>() 
            where TTokenProvider : TokenProvider<TTokenBase>
            where TTokenBase : TokenBase
        {
            _services.AddSingleton<TTokenProvider>();
            _services.AddSingleton<TokenProvider<TTokenBase>>(services => services.GetRequiredService<TTokenProvider>());

            return this;
        }
    }
}
