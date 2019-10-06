using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("grupo_usuario")]
    public class GrupoUsuario
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
    }
}