using System;

namespace MGonzaga.IoC.NETCore.Common.Resources.Models
{
    public class Patrimonio
    {
        public String Nome { get; private set; }
        public int MarcaId { get; private set; }
        public Marca Marca { get; private set; }
        public String Descricao { get; private set; }
        public int NumeroTombo { get; private set; }

    }
}
