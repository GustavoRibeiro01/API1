using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repositorio.Antena
{
    public class AntenaRep :RepositorioBase<API.Models.Antena>
    {
        string query = "";

        public void Delete(int id)
        {
            query = $@"DELETE FROM antena WHERE id = {id}";

            db.Execute(query);
        }
    }
}