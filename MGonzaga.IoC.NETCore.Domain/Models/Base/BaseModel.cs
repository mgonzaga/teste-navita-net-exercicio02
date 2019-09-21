using MGonzaga.IoC.NETCore.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MGonzaga.IoC.NETCore.Domain.Models.Base
{
    public class BaseModel : IBaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
    }
}
