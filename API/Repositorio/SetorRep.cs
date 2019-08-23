using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repositorio
{
    public class SetorRep : RepositorioBase<API.Models.Setor>
    {
        string query = "";

        public void Delete(int id)
        {
            query = $@"DELETE FROM setor WHERE id = {id}";

            db.Execute(query);
        }
    }
}