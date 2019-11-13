using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Data_Transfer_Object.Leitura
{
    public class DtoLeitura
    {
        public string tag { get; set; }
        public DateTime data { get; set; }
        public int antena { get; set; }
        public int operacao { get; set; }
    }
}