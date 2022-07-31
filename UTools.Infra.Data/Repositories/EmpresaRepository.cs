using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTools.Domain.Entities;
using UTools.Domain.Interfaces.Repositories;
using UTools.Infra.Data.Contexts;

namespace UTools.Infra.Data.Repositories
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(SqliteContext context)
        : base(context)
        {
        }

        public async Task<List<Empresa>> GetAllAsync(string cnpj, string nome)
        {
            cnpj = cnpj == null ? string.Empty : cnpj.Trim();
            nome = nome == null ? string.Empty : nome.Trim().ToUpper();
            return await DbSet.AsNoTracking()
                              .Where(x => x.CNPJ.Contains(cnpj)
                                      && (x.Fantasia.ToUpper().Contains(nome) || x.Nome.ToUpper().Contains(nome)))
                              .ToListAsync();
        }

        public async Task<Empresa> GetByCnpjAsync(string cnpj)
        {
            cnpj = cnpj == null ? string.Empty : cnpj.Trim();
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.CNPJ == cnpj);
        }

    }
}
