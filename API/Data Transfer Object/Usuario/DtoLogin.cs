using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Data_Transfer_Object.Usuario
{
    public class DtoLogin
    {
        public int idUsuario { get; set; }
        public int idGrupoUsuario { get; set; }
        public string descricao { get; set; }
    }
}