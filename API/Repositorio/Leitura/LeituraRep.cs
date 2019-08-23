using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repositorio.Leitura
{
    public class LeituraRep : RepositorioBase<API.Models.Leitura>
    {
        string query = "";

        public void Delete(int id)
        {
            query = $@"DELETE FROM leitura WHERE id = {id}";

            db.Execute(query);
        }
    }
}