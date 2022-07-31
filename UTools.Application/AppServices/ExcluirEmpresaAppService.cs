using System.Threading.Tasks;
using UTools.Application.Dtos;
using UTools.Application.Interfaces;
using UTools.Domain.Interfaces.Commands;
using UTools.Domain.Interfaces.Repositories;
using UTools.Domain.Interfaces.Validators;

namespace UTools.Application.AppServices
{
    public class ExcluirEmpresaAppService : IExcluirEmpresaAppService
    {
        private readonly IExcluirEmpresaCommand _excluirEmpresaCommand;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ICnpjValidator _cnpjValidator;

        public ExcluirEmpresaAppService(IExcluirEmpresaCommand excluirEmpresaCommand,
                                        IEmpresaRepository empresaRepository,
                                        ICnpjValidator cnpjValidator)
        {
            _excluirEmpresaCommand = excluirEmpresaCommand;
            _empresaRepository = empresaRepository;
            _cnpjValidator = cnpjValidator;
        }

        public async Task<ResponseDTO> ExecuteAsync(string parameters)
        {
            if (!_cnpjValidator.IsValid(parameters))
                return new ResponseDTO
                {
                    HasError = true,
                    Message = "O CNPJ está inválido"
                };

            var entity = await _empresaRepository.GetByCnpjAsync(parameters);
            var success = await _excluirEmpresaCommand.ExecuteAsync(entity);

            return new ResponseDTO
            {
                HasError = !success,
                Message = !success ? _excluirEmpresaCommand.MessageError : "Empresa excluída com sucesso"
            };
        }
    
    }
}
