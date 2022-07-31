using System.Collections.Generic;
using System.Threading.Tasks;
using UTools.Domain.Entities;

namespace UTools.Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository : IBaseRepository<Empresa>
    {
        Task<List<Empresa>> GetAllAsync(string cnpj, string nome);
        Task<Empresa> GetByCnpjAsync(string cnpj);
    }
}
