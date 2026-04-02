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
    ///  Class for testing JobsApi
    /// </summary>
    public sealed class JobsApiTests : ApiTestsBase
    {
        private readonly IJobsApi _instance;

        public JobsApiTests(): base(Array.Empty<string>())
        {
            _instance = _host.Services.GetRequiredService<IJobsApi>();
        }

        /// <summary>
        /// Test GetJob
        /// </summary>
        [Fact (Skip = "not implemented")]
        public async Task GetJobAsyncTest()
        {
            Guid id = default!;
            var response = await _instance.GetJobAsync(id);
            var model = response.Ok();
            Assert.IsType<JobResponse>(model);
        }

        /// <summary>
        /// Test StreamJob
        /// </summary>
        [Fact (Skip = "not implemented")]
        public async Task StreamJobAsyncTest()
        {
            Guid id = default!;
            var response = await _instance.StreamJobAsync(id);
            var model = response.Ok();
            Assert.IsType<string>(model);
        }
    }
}
