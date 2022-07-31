using Microsoft.EntityFrameworkCore;
using UTools.Domain.Entities;
using UTools.Infra.Data.Mappings;

namespace UTools.Infra.Data.Contexts
{

    public class SqliteContext : DbContext
    {
        public DbSet<Empresa> Empresa { get; set; }

        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(x => System.Diagnostics.Debug.WriteLine(x));
    }
}
