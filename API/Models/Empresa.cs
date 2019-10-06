using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("empresa")]
    public class Empresa
    {
        [Key]
        public int id { get; set; }
        public int id_usuario { get; set; }
        public string nome { get; set; }
        public string razao { get; set; }
        public string cidade { get; set; }
        public string ramo { get; set; }
    }
}