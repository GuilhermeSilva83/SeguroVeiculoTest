
using System.Net.Http.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using SeguroVeiculo.WebApi.Dto;
using System.Diagnostics;

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
        public async Task CotarSeguro()
        {
            var response = await httpClient.PostAsJsonAsync($"/api/seguro/cotar",
                 new AdicionarSeguroDto
                 {
                     Nome = "Guilherme Silva",
                     CPF = "00322421152",
                     DataNascimento = new DateTime(1983, 11, 25),
                     Marca = "BMW",
                     Modelo = "X1",
                     Valor = 90000,
                     Placa = "ABC-010203",
                     
                 });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            if (response.StatusCode !=  HttpStatusCode.OK)
            {
                Debug.WriteLine(response.Content.ToString());
            }
        }
    }
}