using Moq;
using UTools.Domain.Commands;
using UTools.Domain.Interfaces.Repositories;
using Xunit;

namespace UTools.Test
{
    public class CriarEmpresaCommandTest
    {

        [Fact]
        public void ValidCompany()
        {
            var criarEmpresaCommand = new CriarEmpresaCommand(new Mock<IEmpresaRepository>().Object);

            Assert.True(criarEmpresaCommand.ExecuteAsync(new Domain.Entities.Empresa
            {
                CNPJ= "39381712000133",
                Fantasia= "DE LUCHIO CUSTODIO IT",
                Nome= "K. DE LUCHIO CUSTODIO"
            }).Result);
        }

        [Theory]
        [InlineData("", "DE LUCHIO CUSTODIO IT", "K. DE LUCHIO CUSTODIO")]
        [InlineData("39381712000133", "DE LUCHIO CUSTODIO IT", "")]
        [InlineData("15327167000139", "", "MARIA DO CARMO DE JESUS")]
        public void InvalidCompany(string cnpj, string fantasia, string razaoSocial)
        {
            var mockEmpresaRepository = new Mock<IEmpresaRepository>();
            mockEmpresaRepository.Setup(x => x.GetByCnpjAsync("15327167000139")).ReturnsAsync(new Domain.Entities.Empresa { CNPJ = "15327167000139", Nome = "MARIA DO CARMO DE JESUS" });
            var criarEmpresaCommand = new CriarEmpresaCommand(mockEmpresaRepository.Object);

            Assert.True(!criarEmpresaCommand.ExecuteAsync(new Domain.Entities.Empresa
            {
                CNPJ = cnpj,
                Fantasia = fantasia,
                Nome = razaoSocial
            }).Result);
        }

    }
}
