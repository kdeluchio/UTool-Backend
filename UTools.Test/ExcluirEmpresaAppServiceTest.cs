using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UTools.Application.AppServices;
using UTools.Domain.Commands;
using UTools.Domain.Interfaces.Repositories;
using UTools.Domain.Interfaces.Validators;
using Xunit;

namespace UTools.Test
{
    public class ExcluirEmpresaAppServiceTest
    {

        [Fact]
        public void ValidCompany()
        {
            string cnpj = "39381712000133";

            var mockEmpresaRepository = new Mock<IEmpresaRepository>();
            mockEmpresaRepository.Setup(x => x.GetByCnpjAsync(cnpj)).ReturnsAsync(new Domain.Entities.Empresa { CNPJ = "15327167000139", Nome = "MARIA DO CARMO DE JESUS" });

            var mockCnpjValidator = new Mock<ICnpjValidator>();
            mockCnpjValidator.Setup(x => x.IsValid(cnpj)).Returns(true);

            var excluirEmpresaAppService = new ExcluirEmpresaAppService(new ExcluirEmpresaCommand(mockEmpresaRepository.Object),
                                                                    mockEmpresaRepository.Object,
                                                                    mockCnpjValidator.Object);

            Assert.True(!excluirEmpresaAppService.ExecuteAsync(cnpj).Result.HasError);
        }
    }
}
