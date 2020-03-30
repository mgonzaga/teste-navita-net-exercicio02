using MGonzaga.IoC.NETCore.Domain.Interfaces.Base;
using MGonzaga.IoC.NETCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MGonzaga.IoC.NETCore.Data.Context
{
    public class SysDataBaseContext : DbContext, IDbContext
    {
        public SysDataBaseContext()
        {
        }
        public SysDataBaseContext(DbContextOptions<SysDataBaseContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Patrimonio> Patrimonios { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
