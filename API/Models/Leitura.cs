using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("leitura")]
    public class Leitura
    {
        [Key]
        public int id { get; set; }
        public string tag { get; set; }
        public DateTime? data { get; set; }
        public int? antena { get; set; } 
        public int operacao { get; set; }
    }
}