using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }
        public string sexo { get; set; }
        public string profissao { get; set; }
        public string empresa { get; set; }
        public string tag { get; set; }

    }
}