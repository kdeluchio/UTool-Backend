using AutoMapper;
using System.Threading.Tasks;
using UTools.Application.Communication;
using UTools.Application.Dtos;
using UTools.Application.Interfaces;
using UTools.Domain.Entities;
using UTools.Domain.Interfaces.Commands;
using UTools.Domain.Interfaces.Validators;

namespace UTools.Application.AppServices
{
    public class CriarEmpresaAppService : ICriarEmpresaAppService
    {
        private readonly ICriarEmpresaCommand _criarEmpresaCommand;
        private readonly IMapper _mapper;
        private readonly ICnpjValidator _cnpjValidator;

        public CriarEmpresaAppService(ICriarEmpresaCommand criarEmpresaCommand,
                                      IMapper mapper,
                                      ICnpjValidator cnpjValidator)
        {
            _criarEmpresaCommand = criarEmpresaCommand;
            _mapper = mapper;
            _cnpjValidator = cnpjValidator;
        }

        public async Task<ResponseDTO> ExecuteAsync(CriarEmpresaDTO parameters)
        {
            if (!_cnpjValidator.IsValid(parameters.CNPJ))
                return new ResponseDTO
                {
                    HasError = true,
                    Message ="O CNPJ está inválido"
                };

            var restClient = RestClient.GetInstance();
            var company = await restClient.GetAsync<CadastroEmpresaDTO>($"https://receitaws.com.br/v1/cnpj/{parameters.CNPJ}");

            var newEntity = _mapper.Map<Empresa>(company);
            var success = await _criarEmpresaCommand.ExecuteAsync(newEntity);

            return new ResponseDTO
            {
                HasError = !success,
                Message = !success ? _criarEmpresaCommand.MessageError : "Empresa criada com sucesso"
            };
        }

    }
}
