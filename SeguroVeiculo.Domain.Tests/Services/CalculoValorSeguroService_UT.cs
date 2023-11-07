using SeguroVeiculo.Domain.Services;

namespace SeguroVeiculo.Domain.Tests.Services
{
    public class CalculoValorSeguroService_UT
    {
        [Fact]
        public void CalcularSeguro_01()
        {
            // arrange
            var s = new CalculoValorSeguroService();

            // act
            var resultado = s.CalcularSeguro(10000);

            // assert
            Assert.Equal(2.5m, resultado.TaxaRisco, 2); // taxa risco
            Assert.Equal(250m, resultado.PremioRisco, 2); // premio risco
            Assert.Equal(257.5m, resultado.PremioPuro, 2); // premio puro
            Assert.Equal(270.37m, resultado.PremioComercial); // valor total
        }
    }
}