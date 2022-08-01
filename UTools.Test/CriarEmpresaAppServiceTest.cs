using AutoMapper;
using Moq;
using UTools.Application.AppServices;
using UTools.Domain.Commands;
using UTools.Domain.Interfaces.Repositories;
using UTools.Domain.Interfaces.Validators;
using UTools.Infra.CrossCutting;
using Xunit;

namespace UTools.Test
{
    public class CriarEmpresaAppServiceTest
    {

        [Fact]
        public void ValidCompany()
        {
            string cnpj = "39381712000133";

            var mockCnpjValidator = new Mock<ICnpjValidator>();
            mockCnpjValidator.Setup(x => x.IsValid(cnpj)).Returns(true);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Mappers()); 
            });
            var mapper = mockMapper.CreateMapper();

            var criarEmpresaAppService = new CriarEmpresaAppService(new CriarEmpresaCommand(new Mock<IEmpresaRepository>().Object),
                                                                    mapper,
                                                                    mockCnpjValidator.Object);

            Assert.True(!criarEmpresaAppService.ExecuteAsync(new Application.Dtos.CriarEmpresaDTO
            {
                CNPJ = cnpj
            }).Result.HasError);
        }

    }
}
