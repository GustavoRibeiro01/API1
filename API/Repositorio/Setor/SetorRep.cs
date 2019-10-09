using API.Data_Transfer_Object.Setor;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API.Repositorio.Setor
{
    public class SetorRep : RepositorioBase<API.Models.Setor>
    {
        string query = "";
        
        public IEnumerable<DtoUltimoSetorTag> UltimoSetorTag(string storedName)
        {
            return db.Query<DtoUltimoSetorTag>(storedName, null, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<DtoRastreio> Rastreio(string storedName, string nome)
        {
            var parameters = new DynamicParameters();
            parameters.Add("nome", nome);

            return db.Query<DtoRastreio>(storedName, parameters, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            query = $@"DELETE FROM setor WHERE id = {id}";

            db.Execute(query);
        }
    }
}