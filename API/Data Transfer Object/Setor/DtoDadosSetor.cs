using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Data_Transfer_Object.Setor
{
    public class DtoDadosSetor
    {
        public string id_setor { get; set; }
        public string qtd_passaram { get; set; }
        public string qtd_atual { get; set; }
        public string abreviacao { get; set; }
        public string descricao { get; set; }
    }
}