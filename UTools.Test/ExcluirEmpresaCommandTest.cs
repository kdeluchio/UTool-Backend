using Moq;
using UTools.Domain.Commands;
using UTools.Domain.Interfaces.Commands;
using UTools.Domain.Interfaces.Repositories;
using Xunit;

namespace UTools.Test
{
    public class ExcluirEmpresaCommandTest
    {
        private readonly IExcluirEmpresaCommand _excluirEmpresaCommand;

        public ExcluirEmpresaCommandTest()
        {
            _excluirEmpresaCommand = new ExcluirEmpresaCommand(new Mock<IEmpresaRepository>().Object);
        }

        [Fact]
        public void ValidCompany()
        {
            Assert.True(_excluirEmpresaCommand.ExecuteAsync(new Domain.Entities.Empresa
            {
                CNPJ = "39381712000133",
                Fantasia = "DE LUCHIO CUSTODIO IT",
                Nome = "K. DE LUCHIO CUSTODIO"
            }).Result);
        }

        [Fact]
        public void InvalidCompany()
        {
            Assert.True(!_excluirEmpresaCommand.ExecuteAsync(null).Result);
        }

    }
}
