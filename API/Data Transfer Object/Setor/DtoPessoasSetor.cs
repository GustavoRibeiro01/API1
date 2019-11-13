using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Data_Transfer_Object.Setor
{
    public class DtoPessoasSetor
    {
        public string tag { get; set; }
        public string cliente { get; set; }
        public int idade { get; set; }
        public string cidade { get; set; }
        public string profissao { get; set; }
        public string email { get; set; }
    }
}