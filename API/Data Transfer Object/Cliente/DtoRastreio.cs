using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Data_Transfer_Object.Cliente
{
    public class DtoRastreio
    {
        public string cliente { get; set; }
        public string profissao { get; set; }
        public string setor { get; set; }
        public string segundos { get; set; }
    }
}