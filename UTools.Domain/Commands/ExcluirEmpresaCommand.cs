using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UTools.Domain.Entities;
using UTools.Domain.Interfaces.Commands;
using UTools.Domain.Interfaces.Repositories;

namespace UTools.Domain.Commands
{
    public class ExcluirEmpresaCommand : IExcluirEmpresaCommand
    {
        private readonly IEmpresaRepository _empresaRepository;
        public string MessageError { get; set; }

        public ExcluirEmpresaCommand(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<bool> ExecuteAsync(Empresa entity)
        {
            if (!Validate(entity))
                return false;

            await _empresaRepository.DeleteAsync(entity);
            return true;
        }

        private bool Validate(Empresa entity)
        {
            if (entity == null)
            {
                MessageError = "A empresa não foi localizada.";
                return false;
            }

            return true;
        }

    }
}
