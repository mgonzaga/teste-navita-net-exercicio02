using System;
using System.Collections.Generic;
using System.Text;

namespace MGonzaga.IoC.NETCore.Common.Resources.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String NomeCompleto { get;  set; }
        public String EnderecoEmail { get;  set; }
        public bool EmailConfirmado { get;  set; }
        public String Senha { get;  set; }
        public DateTime DataCriacao { get;  set; }
        public bool Bloqueado { get; set; }
        public DateTime DataUltimoAcesso { get; set; }
        public int ContatorSenhasErradas { get; set; }
        public Guid? UniqueId { get; set; }
        public string Locale { get; set; }
        public int OAuthProvider { get; set; }
        public String OAuthUId { get; set; }
    }
}
