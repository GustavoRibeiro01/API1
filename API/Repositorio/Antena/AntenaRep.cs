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

        public IEnumerable<API.Models.Antena> GetDisponiveis()
        {

            query = $@"select antena.id, antena.antena from antena where antena.id not in (select setor_antena.id_antena from setor_antena)";

            return db.Query<API.Models.Antena>(query).ToList();
        }


        public void Delete(int id)
        {
            query = $@"DELETE FROM antena WHERE id = {id}";

            db.Execute(query);
        }

        public void addAntenaSetor(int id_setor, int id_antena)
        {
            query = $@"insert into setor_antena (id_setor, id_antena) values ('" + id_setor + "', '" + id_antena + "')";

            db.Execute(query);
        }

        public void deleteAntenaSetor(int id_setor, int id_antena)
        {
            query = $@"delete setor_antena where setor_antena.id_setor='" + id_setor + "' and setor_antena.id_antena='" + id_antena + "'";

            db.Execute(query);
        }
    }
}