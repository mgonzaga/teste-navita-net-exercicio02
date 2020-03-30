using MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories.Base;
using MGonzaga.IoC.NETCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Domain.Interfaces.Repositories
{
    public interface IMarcaRepository : IWriteRepository<Marca>
    {
        Boolean ExisteNomeMarca(String nome, int MarcaId);
    }
}
