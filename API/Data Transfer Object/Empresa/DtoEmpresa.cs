using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Data_Transfer_Object.Empresa
{
    public class DtoEmpresa
    {
        public int id { get; set; }
        public string nome_usuario { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public int id_grupo { get; set; }
        public int id_usuario { get; set; }
        public string nome { get; set; }
        public string razao { get; set; }
        public string cidade { get; set; }
        public string ramo { get; set; }

    }
}