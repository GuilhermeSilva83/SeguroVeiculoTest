
using System.Net.Http.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using SeguroVeiculo.WebApi.Dto;

namespace SeguroVeiculo.WebApi.Tests
{
    public class SeguroControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient httpClient;

        public SeguroControllerTest(WebApplicationFactory<Program> factory)
        {
            httpClient = factory.CreateClient();
        }


        [Fact]
        public async Task PostTest()
        {
            var response = await httpClient.PostAsJsonAsync($"/api/seguro/cotar",
                 new AdicionarSeguroDto
                 {
                     CPF = "00322421152",
                     DataNascimento = new DateTime(1983, 11, 25),
                     
                 });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}