using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repositorio.Cliente
{
    public class ClienteRep : RepositorioBase<API.Models.Cliente>
    {
        string query = "";

        public IEnumerable<API.Models.Cliente> GetFilter(int id, string nome, string cpf, string sexo, string profissao)
        {

            query = $@"SELECT 
	                        * 
	
                        FROM cliente

                        WHERE id > 0
	                        {(id > 0 ? $"AND id = {id}": null)}
	                        {(nome != null ? $"AND nome LIKE '{nome}%'" : null)}
	                        {(cpf != null ? $"AND cpf LIKE '{cpf}%'" : null)}
	                        {(sexo != null ? $"AND sexo LIKE '{sexo}%'" : null)}
	                        {(profissao != null ? $"AND profissao LIKE '{profissao}%'" : null)}";

            return db.Query<API.Models.Cliente>(query).ToList();
        }
    }
}