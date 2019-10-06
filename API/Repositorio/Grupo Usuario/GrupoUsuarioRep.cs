using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repositorio.Grupo_Usuario
{
    public class GrupoUsuarioRep : RepositorioBase<API.Models.GrupoUsuario>
    {
        private string query = "";

        public void Delete(int id)
        {
            query = $@"DELETE FROM grupo_usuario WHERE id = {id}";

            db.Execute(query);
        }
    }
}