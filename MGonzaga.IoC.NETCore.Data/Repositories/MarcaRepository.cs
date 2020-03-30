using MGonzaga.IoC.NETCore.Domain.Impl.Repositories.Base;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Base;
using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories;
using MGonzaga.IoC.NETCore.Domain.Models;
using MGonzaga.IoC.NETCore.Domain.Models.Filters;
using System.Linq;

namespace MGonzaga.IoC.NETCore.Data.Repositories
{
    public class MarcaRepository : WriteRepositoryImpl<Marca>, IMarcaRepository
    {
        private readonly IDbContext db;
        public MarcaRepository(IDbContext db) : base(db)
        {
            this.db = db;
        }
        public bool ExisteNomeMarca(string nome, int MarcaId)
        {
            return db.Set<Marca>().WithNome(nome).WithId(MarcaId).Any();
        }
    }
}
