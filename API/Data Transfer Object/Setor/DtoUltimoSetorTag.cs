using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Data_Transfer_Object.Setor
{
    public class DtoUltimoSetorTag
    {
        public string tag { get; set; }
        public string setor { get; set; }
        public int id_cliente { get; set; }
        public string cliente { get; set; }
    }
}