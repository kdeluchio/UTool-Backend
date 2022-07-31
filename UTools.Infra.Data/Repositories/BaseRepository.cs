using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using UTools.Domain.Entities;
using UTools.Domain.Interfaces.Repositories;
using UTools.Infra.Data.Contexts;

namespace UTools.Infra.Data.Repositories
{

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly SqliteContext Db;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(SqliteContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public async Task<T> InsertAsync(T obj)
        {
            try
            {
                DbSet.Add(obj);
                await Db.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<T> UpdateAsync(T current, T obj)
        {
            try
            {
                if (current == null)
                {
                    return null;
                }

                //Como é case sensitive igualo a PK com o que retornou do banco
                obj.Id = current.Id;

                var dbEntry = Db.ChangeTracker.Entries<BaseEntity>()
                                              .FirstOrDefault(x => x.Entity.Id == current.Id
                                                                && x.Entity.GetType() == current.GetType());

                if (dbEntry == null)
                {
                    dbEntry = Db.Entry<BaseEntity>(current);
                }

                dbEntry.CurrentValues.SetValues(obj);
                dbEntry.State = EntityState.Modified;

                await Db.SaveChangesAsync();

                return obj;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(T current)
        {
            try
            {
                if (current == null)
                {
                    return false;
                }

                DbSet.Remove(current);
                await Db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var current = await DbSet.SingleOrDefaultAsync(x => x.Id == id);
            return await DeleteAsync(current);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
