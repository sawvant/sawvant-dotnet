/*
 * Sawvant Cutting Optimization API — .NET SDK
 *
 * File generated from our OpenAPI spec; DO NOT EDIT.
 */

using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Security.Cryptography;
using Sawvant.Client;
using Sawvant.Api;
using Sawvant.Extensions;
using Xunit;

namespace Sawvant.Test.Api
{
    /// <summary>
    ///  Tests the dependency injection.
    /// </summary>
    public class DependencyInjectionTest
    {
        private readonly IHost _hostUsingConfigureWithoutAClient =
            Host.CreateDefaultBuilder([]).ConfigureApi((context, services, options) =>
            {
                ApiKeyToken apiKeyToken1 = new("<token>", ClientUtils.ApiKeyHeader.X_API_Key, timeout: TimeSpan.FromSeconds(1));
                options.AddTokens(apiKeyToken1);
            })
            .Build();

        private readonly IHost _hostUsingConfigureWithAClient =
            Host.CreateDefaultBuilder([]).ConfigureApi((context, services, options) =>
            {
                ApiKeyToken apiKeyToken1 = new("<token>", ClientUtils.ApiKeyHeader.X_API_Key, timeout: TimeSpan.FromSeconds(1));
                options.AddTokens(apiKeyToken1);
                options.AddApiHttpClients(client => client.BaseAddress = new Uri(ClientUtils.BASE_ADDRESS));
            })
            .Build();

        private readonly IHost _hostUsingAddWithoutAClient =
            Host.CreateDefaultBuilder([]).ConfigureServices((host, services) =>
            {
                services.AddApi(options =>
                {
                    ApiKeyToken apiKeyToken1 = new("<token>", ClientUtils.ApiKeyHeader.X_API_Key, timeout: TimeSpan.FromSeconds(1));
                    options.AddTokens(apiKeyToken1);
                });
            })
            .Build();

        private readonly IHost _hostUsingAddWithAClient =
            Host.CreateDefaultBuilder([]).ConfigureServices((host, services) =>
            {
                services.AddApi(options =>
                {
                    ApiKeyToken apiKeyToken1 = new("<token>", ClientUtils.ApiKeyHeader.X_API_Key, timeout: TimeSpan.FromSeconds(1));
                    options.AddTokens(apiKeyToken1);
                    options.AddApiHttpClients(client => client.BaseAddress = new Uri(ClientUtils.BASE_ADDRESS));
                });
            })
            .Build();

        /// <summary>
        /// Test dependency injection when using the configure method
        /// </summary>
        [Fact]
        public void ConfigureApiWithAClientTest()
        {
            var jobsApi = _hostUsingConfigureWithAClient.Services.GetRequiredService<IJobsApi>();
            Assert.True(jobsApi.HttpClient.BaseAddress != null);

            var optimizationApi = _hostUsingConfigureWithAClient.Services.GetRequiredService<IOptimizationApi>();
            Assert.True(optimizationApi.HttpClient.BaseAddress != null);

            var systemApi = _hostUsingConfigureWithAClient.Services.GetRequiredService<ISystemApi>();
            Assert.True(systemApi.HttpClient.BaseAddress != null);
        }

        /// <summary>
        /// Test dependency injection when using the configure method
        /// </summary>
        [Fact]
        public void ConfigureApiWithoutAClientTest()
        {
            var jobsApi = _hostUsingConfigureWithoutAClient.Services.GetRequiredService<IJobsApi>();
            Assert.True(jobsApi.HttpClient.BaseAddress != null);

            var optimizationApi = _hostUsingConfigureWithoutAClient.Services.GetRequiredService<IOptimizationApi>();
            Assert.True(optimizationApi.HttpClient.BaseAddress != null);

            var systemApi = _hostUsingConfigureWithoutAClient.Services.GetRequiredService<ISystemApi>();
            Assert.True(systemApi.HttpClient.BaseAddress != null);
        }

        /// <summary>
        /// Test dependency injection when using the add method
        /// </summary>
        [Fact]
        public void AddApiWithAClientTest()
        {
            var jobsApi = _hostUsingAddWithAClient.Services.GetRequiredService<IJobsApi>();
            Assert.True(jobsApi.HttpClient.BaseAddress != null);
            
            var optimizationApi = _hostUsingAddWithAClient.Services.GetRequiredService<IOptimizationApi>();
            Assert.True(optimizationApi.HttpClient.BaseAddress != null);
            
            var systemApi = _hostUsingAddWithAClient.Services.GetRequiredService<ISystemApi>();
            Assert.True(systemApi.HttpClient.BaseAddress != null);
        }

        /// <summary>
        /// Test dependency injection when using the add method
        /// </summary>
        [Fact]
        public void AddApiWithoutAClientTest()
        {
            var jobsApi = _hostUsingAddWithoutAClient.Services.GetRequiredService<IJobsApi>();
            Assert.True(jobsApi.HttpClient.BaseAddress != null);

            var optimizationApi = _hostUsingAddWithoutAClient.Services.GetRequiredService<IOptimizationApi>();
            Assert.True(optimizationApi.HttpClient.BaseAddress != null);

            var systemApi = _hostUsingAddWithoutAClient.Services.GetRequiredService<ISystemApi>();
            Assert.True(systemApi.HttpClient.BaseAddress != null);
        }
    }
}
