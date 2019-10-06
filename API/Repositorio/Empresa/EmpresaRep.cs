using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repositorio.Empresa
{
    public class EmpresaRep : RepositorioBase<API.Models.Empresa>
    {
        private string query = "";

        public void Delete(int id)
        {
            query = $@"DELETE FROM empresa WHERE id = {id}";

            db.Execute(query);
        }
    }
}