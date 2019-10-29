using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Data_Transfer_Object.Usuario
{
    public class DtoLogin
    {
        public int idUsuario { get; set; }
        public string nome { get; set; }
        public int idGrupoUsuario { get; set; }
        public string descricaoGrupo { get; set; }
        public int? idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
        public int? idSetor { get; set; }
        public string descricaoSetor { get; set; }
    }
}