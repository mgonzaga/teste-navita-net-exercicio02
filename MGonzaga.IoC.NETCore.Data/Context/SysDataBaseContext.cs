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
        public DbSet<Links> Links { get; set;}
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// "ToTable" Method In Microsoft.EntityFrameworkCore.Relational package.
            modelBuilder.Entity<User>(_ =>
            {
                _.ToTable("Users");
                _.HasIndex(b => b.Email).HasName("idx_user_email").IsUnique(true);
                //_.Property(c => c.FullName).HasColumnType("varchar(300)").IsRequired(true);
                //_.Property(c => c.Email).HasColumnType("varchar(300)").IsRequired(true);
                //_.Property(c => c.Password).HasColumnType("varchar(50)").IsRequired(true);
                //_.Property(c => c.ConfirmedEmail).IsRequired(true).HasDefaultValue(false);
                //_.Property(c => c.CreateDate).IsRequired(true).HasDefaultValueSql("GetDate()");
                //_.Property(c => c.Blocked).IsRequired(true).HasDefaultValue(false);
                //_.Property(x => x.UniqueId).HasDefaultValueSql("NEWID()");
            });

            modelBuilder.Entity<Links>(_ =>
            {
                _.ToTable("Links");
                _.HasIndex(b => b.UniqueId).HasName("idx_Links_UniqueId").IsUnique(true);
                //_.Property(x => x.UniqueId).HasDefaultValueSql("NEWID()");
                //_.Property(c => c.CreateDate).IsRequired(true).HasDefaultValueSql("getdate()");
                //_.Property(c => c.ExpireDate).IsRequired(true);
                //_.Property(c => c.Type).IsRequired(true);

            });
        }
        */
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
