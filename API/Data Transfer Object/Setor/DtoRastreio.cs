using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Data_Transfer_Object.Setor
{
    public class DtoRastreio
    {
        public string tag { get; set; }
        public string cliente { get; set; }
        public string profissao { get; set; }
        public string setor { get; set; }
        public string descricaoItensSetor { get; set; }
        public string dia { get; set; }
        public DateTime data { get; set; }
        public string dataFIM { get; set; }
        public string segundos { get; set; }
    }
}