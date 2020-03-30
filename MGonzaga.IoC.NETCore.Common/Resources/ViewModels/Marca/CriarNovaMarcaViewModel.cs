using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MGonzaga.IoC.NETCore.Common.Resources.ViewModels.Marca
{
    public class CriarNovaMarcaViewModel
    {
        [Required]
        public String Nome { get; set; }
    }
}
