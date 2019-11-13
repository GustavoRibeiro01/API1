using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("setor")]
    public class Setor
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
        public string abreviacao { get; set; }

    }
}