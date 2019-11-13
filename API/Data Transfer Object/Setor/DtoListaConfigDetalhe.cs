using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Data_Transfer_Object.Setor
{
    public class DtoListaConfigDetalhe
    {
        public string idSetor { get; set; }
        public string descricao { get; set; }
        public string abreviacao { get; set; }
        public string idAntena { get; set; }
        public string antena { get; set; }
    }
}