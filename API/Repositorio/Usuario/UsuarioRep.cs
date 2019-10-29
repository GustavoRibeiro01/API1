using API.Data_Transfer_Object.Usuario;
using API.Models;
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

        public DtoLogin Login(string nome, string senha)
        {
            query = $@"SELECT 
	                        u.id idUsuario,
							u.nome,
	                        gu.id idGrupoUsuario,
	                        gu.descricao as descricaoGrupo,
							empresa.id as idEmpresa,
							empresa.nome as nomeEmpresa,
							setor.id as idSetor,
							setor.abreviacao as descricaoSetor
	
                        FROM usuario u
	                        INNER JOIN grupo_usuario gu ON gu.id = u.id_grupo
							left join empresa on u.id = empresa.id_usuario
							left join setor on setor.id = empresa.id_setor

                        WHERE u.nome = '{nome}'
	                        AND u.senha = '{senha}'";

            return db.Query<DtoLogin>(query).FirstOrDefault();
        }

        public void Delete(int id)
        {
            query = $@"DELETE FROM usuario WHERE id = {id}";

            db.Execute(query);
        }
    }
}