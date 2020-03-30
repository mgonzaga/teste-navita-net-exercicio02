using MGonzaga.IoC.NETCore.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MGonzaga.IoC.NETCore.Domain.Models
{
    public class Patrimonio : BaseModel
    {
        public String Nome { get; private set; }
        public int MarcaId { get; private set; }
        public Marca Marca { get; private set; }
        public String Descricao { get; private set; }
        public int NumeroTombo { get; private set; }

        public void AlterNome(String novoNome) => Nome = novoNome;
        public void AlterMarcaId(int novaMarcaId) => MarcaId = novaMarcaId;
        public void AlterMarca(Marca novaMarca) => Marca = novaMarca;
        public void AlterDescricao(String novaDescricao) => Descricao = novaDescricao;
        public void AlterNumeroTombo(int novoNumeroTombo) => NumeroTombo = novoNumeroTombo;

    }
}
