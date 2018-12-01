using Microsoft.AspNetCore.Mvc.Controllers;
using webserver.Controllers;
using Xunit;
using webserver.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace EFCoreWebAPI.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(1 + 1 == 2);
        }
        [Fact]
        public void Test2()
        {
            Assert.Equal(1,1);
        }

        [Fact]
        public void GetActorByIdSmokeTest1()
        {
            var controller = new ActorController();
            var result = controller.Get(101) as OkObjectResult;
            var actor = result.Value as Actor;

            Assert.Equal(actor.Actor_ID, 101);
            Assert.Equal(actor.first_name, "SUSAN");
            Assert.Equal(actor.last_name, "DAVIS");
        }

        [Fact]
        public async void GetActorByIdSmokeTest2()
        {
            using(var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("https://localhost:44331");
                var acceptType = new MediaTypeWithQualityHeaderValue("application/json");
                httpclient.DefaultRequestHeaders.Clear();
                httpclient.DefaultRequestHeaders.Accept.Add(acceptType);
                var response = await httpclient.GetAsync("api/actor/1");
                string jsonString = null;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                    Assert.NotNull(jsonString);
                }

                Actor actor = JsonConvert.DeserializeObject<Actor>(jsonString);
                Assert.NotNull(actor);
                Assert.Equal(actor.Actor_ID, 01);
                Assert.Equal(actor.first_name, "PENELOPE");
                Assert.Equal(actor.last_name, "GUINESS");                
            }
        }
    }
}
