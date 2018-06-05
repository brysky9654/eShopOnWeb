﻿using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.eShopWeb.Web;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.eShopWeb.FunctionalTests.WebRazorPages
{
    public class OrderIndexOnGet : IClassFixture<CustomWebRazorPagesApplicationFactory<Startup>>
    {
        public OrderIndexOnGet(CustomWebRazorPagesApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        public HttpClient Client { get; }

        [Fact]
        public async Task ReturnsRedirectGivenAnonymousUser()
        {
            var response = await Client.GetAsync("/Order/Index");
            var redirectLocation = response.Headers.Location.OriginalString;

            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Contains("Account/Signin", redirectLocation);
        }
    }
}
