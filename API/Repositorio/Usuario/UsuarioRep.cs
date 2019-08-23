using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace API.Repositorio.Usuario
{
    public class UsuarioRep : RepositorioBase<API.Models.Usuario>
    {
        string query = "";

        public void Delete(int id)
        {
            query = $@"DELETE FROM usuario WHERE id = {id}";

            db.Execute(query);
        }
    }
}