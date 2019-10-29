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
        
        public IEnumerable<DtoUltimoSetorTag> UltimoSetorPessoa(string storedName)
        {
            return db.Query<DtoUltimoSetorTag>(storedName, null, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<DtoRastreio> Rastreio(string storedName, string nome)
        {
            var parameters = new DynamicParameters();
            parameters.Add("nome", nome);

            return db.Query<DtoRastreio>(storedName, parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<DtoQtdPessoasSetor> QtdPessoasSetor(string storedName)
        {
            return db.Query<DtoQtdPessoasSetor>(storedName, null, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<DtoFaixaIdade> FaixaIdadePessoas(string storedName)
        {
            return db.Query<DtoFaixaIdade>(storedName, null, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<DtoFaixaIdade> FaixaIdadePessoas(string storedName, int idSetor)
        {
            var parameters = new DynamicParameters();
            parameters.Add("idsetor", idSetor);

            return db.Query<DtoFaixaIdade>(storedName, parameters, commandType: CommandType.StoredProcedure);
        }



        public IEnumerable<DtoPessoasSetor> PessoasSetor(string storedName, int idSetor)
        {
            var parameters = new DynamicParameters();
            parameters.Add("idSetor", idSetor);

            return db.Query<DtoPessoasSetor>(storedName, parameters, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            query = $@"DELETE FROM setor WHERE id = {id}";

            db.Execute(query);
        }

        public DtoDadosSetor DadosEventoSetor(string storedName, int idSetor)
        {
            var parameters = new DynamicParameters();
            parameters.Add("idSetor", idSetor);

            return db.Query<DtoDadosSetor>(storedName, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public DtoDadosSetor DadosEventoGeral(string storedName)
        {
            return db.Query<DtoDadosSetor>(storedName, null, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}