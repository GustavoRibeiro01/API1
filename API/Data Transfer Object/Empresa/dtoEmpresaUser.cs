using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Data_Transfer_Object.Empresa
{
    public class dtoEmpresaUser
    {
        public int idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
        public string razaoEmpresa { get; set; }
        public string cidadeEmpresa { get; set; }
        public string ramoEmpresa { get; set; }
        public string idSetor { get; set; }
        public string descricaoSetor { get; set; }
        public string abreviacaoSetor { get; set; }
        public string nomeUsuario { get; set; }
    }
}