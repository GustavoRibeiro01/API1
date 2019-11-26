using API.Data_Transfer_Object.Cliente;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API.Repositorio.Leitura
{
    public class LeituraRep : RepositorioBase<API.Models.Leitura>
    {
        string query = "";

        public IEnumerable<DtoRastreio> Rastreio(string nome)
        {
            var parameters = new DynamicParameters();

            parameters.Add("nome", nome);

            return db.Query<DtoRastreio>("sp_Rastreio",parameters, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            query = $@"DELETE FROM leitura WHERE id = {id}";

            db.Execute(query);
        }
    }
}