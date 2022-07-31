using System.Threading.Tasks;
using UTools.Domain.Entities;
using UTools.Domain.Interfaces.Commands;
using UTools.Domain.Interfaces.Repositories;

namespace UTools.Domain.Commands
{
    public class CriarEmpresaCommand : ICriarEmpresaCommand
    {
        private readonly IEmpresaRepository _empresaRepository;
        public string MessageError { get; set; }

        public CriarEmpresaCommand(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<bool> ExecuteAsync(Empresa entity)
        {
            if (!Validate(entity))
                return false;

            await _empresaRepository.InsertAsync(entity);
            return true;
        }

        private bool Validate(Empresa entity)
        {
            if (string.IsNullOrEmpty(entity.CNPJ))
            {
                MessageError = "CNPJ não foi localizado na receita federal";
                return false;
            }

            var company = _empresaRepository.GetByCnpjAsync(entity.CNPJ).Result;
            if (company != null)
            {
                MessageError = "CNPJ já está cadastrado no sistema";
                return false;
            }

            if (string.IsNullOrEmpty(entity.Nome))
            {
                MessageError = "Razão social é obrigatorio";
                return false;
            }

            return true;
        }

    }
}
