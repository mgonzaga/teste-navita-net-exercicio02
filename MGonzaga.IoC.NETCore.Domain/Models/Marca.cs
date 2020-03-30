using MGonzaga.IoC.NETCore.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace MGonzaga.IoC.NETCore.Domain.Models
{
    public class Marca : BaseModel
    {
        public String Nome { get; private set; }
        public void AlterNome(String novoNome) => Nome = novoNome;
        public virtual List<Patrimonio> Patrimonios { get; set; }

    }
}
