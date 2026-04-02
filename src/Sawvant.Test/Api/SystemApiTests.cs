/*
 * Sawvant Cutting Optimization API — .NET SDK
 *
 * File generated from our OpenAPI spec; DO NOT EDIT.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Sawvant.Api;
using Sawvant.Model;


/* *********************************************************************************
*              Follow these manual steps to construct tests.
*              This file will not be overwritten.
*  *********************************************************************************
* 1. Navigate to ApiTests.Base.cs and ensure any tokens are being created correctly.
*    Take care not to commit credentials to any repository.
*
* 2. Mocking is coordinated by ApiTestsBase#AddApiHttpClients.
*    To mock the client, use the generic AddApiHttpClients.
*    To mock the server, change the client's BaseAddress.
*
* 3. Locate the test you want below
*      - remove the skip property from the Fact attribute
*      - set the value of any variables if necessary
*
* 4. Run the tests and ensure they work.
*
*/


namespace Sawvant.Test.Api
{
    /// <summary>
    ///  Class for testing SystemApi
    /// </summary>
    public sealed class SystemApiTests : ApiTestsBase
    {
        private readonly ISystemApi _instance;

        public SystemApiTests(): base(Array.Empty<string>())
        {
            _instance = _host.Services.GetRequiredService<ISystemApi>();
        }

        /// <summary>
        /// Test GetHealth
        /// </summary>
        [Fact (Skip = "not implemented")]
        public async Task GetHealthAsyncTest()
        {
            var response = await _instance.GetHealthAsync();
            var model = response.Ok();
            Assert.IsType<HealthResponse>(model);
        }

        /// <summary>
        /// Test ListTiers
        /// </summary>
        [Fact (Skip = "not implemented")]
        public async Task ListTiersAsyncTest()
        {
            var response = await _instance.ListTiersAsync();
            var model = response.Ok();
            Assert.IsType<List<TierDefinition>>(model);
        }
    }
}
