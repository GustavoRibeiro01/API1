﻿using API.Data_Transfer_Object.Empresa;
using Dapper;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Repositorio.Usuario;
using System.Transactions;
using System.Data;

namespace API.Repositorio.Empresa
{
    public class EmpresaRep : RepositorioBase<API.Models.Empresa>
    {
        private string query = "";

        public Models.Empresa GetEmpresaUsuario(int IdUsuario)
        {
            query = $@"SELECT * FROM empresa WHERE id_usuario = {IdUsuario}";

            return db.Query<Models.Empresa>(query).FirstOrDefault();
        }

        public void GravarEmpresa(DtoEmpresa dtoempresa)
        {
            try
            {
                using (TransactionScope tscope = new TransactionScope())
                {

                    var usuario = new Models.Usuario();
                    var empresa = new Models.Empresa();

                    usuario.nome = dtoempresa.nome;
                    usuario.email = dtoempresa.email;
                    usuario.senha = dtoempresa.senha;
                    usuario.id_grupo = dtoempresa.id_grupo;

                    using (var db = new UsuarioRep())
                    {
                        empresa.id_usuario = (int)db.Insert(usuario);
                    }

                    empresa.nome = dtoempresa.nome;
                    empresa.ramo = dtoempresa.ramo;
                    empresa.razao = dtoempresa.razao;
                    empresa.cidade = dtoempresa.cidade;

                    using (var db = new EmpresaRep())
                    {
                        db.Insert(empresa);
                    }

                    tscope.Complete();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gravar dados!");
            }
        }

        public void UpdateEmpresa(DtoEmpresa dtoempresa)
        {
            try
            {
                using (TransactionScope tscope = new TransactionScope())
                {

                    var usuario = new Models.Usuario();
                    var empresa = new Models.Empresa();

                    usuario.id = dtoempresa.id_usuario;
                    usuario.nome = dtoempresa.nome;
                    usuario.email = dtoempresa.email;
                    usuario.senha = dtoempresa.senha;
                    usuario.id_grupo = dtoempresa.id_grupo;

                    using (var db = new UsuarioRep())
                    {
                        db.Update(usuario);
                    }

                    empresa.id = dtoempresa.id;
                    empresa.nome = dtoempresa.nome;
                    empresa.ramo = dtoempresa.ramo;
                    empresa.razao = dtoempresa.razao;
                    empresa.cidade = dtoempresa.cidade;
                    empresa.id_usuario = dtoempresa.id_usuario;

                    using (var db = new EmpresaRep())
                    {
                        db.Update(empresa);
                    }

                    tscope.Complete();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gravar dados!");
            }
        }

        public void GravarEmpresa(Models.Usuario usuario, Models.Empresa empresa)
        {
            try
            {
                using (TransactionScope tscope = new TransactionScope())
                {
                   
                    using (var db = new UsuarioRep())
                    {
                        empresa.id_usuario = (int)db.Insert(usuario);
                    }

                    using (var db = new EmpresaRep())
                    {
                        db.Insert(empresa);
                    }

                    tscope.Complete();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gravar dados!");
            }
        }

        public void UpdateEmpresa(Models.Usuario usuario, Models.Empresa empresa)
        {
            try
            {
                using (TransactionScope tscope = new TransactionScope())
                {

                    using (var db = new UsuarioRep())
                    {
                        db.Update(usuario);
                    }

                    using (var db = new EmpresaRep())
                    {
                        db.Update(empresa);
                    }

                    tscope.Complete();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gravar dados!");
            }
        }

        public void Delete(int id)
        {
            var empresa = this.Get(id);

            using (TransactionScope tscope = new TransactionScope())
            {
                query = $@"DELETE FROM empresa WHERE id = {id}";

                db.Execute(query);

                query = $@"DELETE FROM usuario WHERE id = {empresa.id_usuario}";

                db.Execute(query);

                tscope.Complete();
            }
                
        }

        public dtoEmpresaUser GetListaEmpresaUser(int id)
        {
            query = $@"select empresa.id as 'idEmpresa', empresa.nome as 'nomeEmpresa', empresa.razao as 'razaoEmpresa', 
                    empresa.cidade as 'cidadeEmpresa', empresa.ramo as 'ramoEmpresa', setor.id as 'idSetor', setor.descricao as 'descricaoSetor', setor.abreviacao as 'abreviacaoSetor',  
                    usuario.nome 'nomeUsuario' from empresa inner join usuario on usuario.id=empresa.id_usuario inner join setor on setor.id=empresa.id_setor
                    where empresa.id={id}";

            return db.Query<dtoEmpresaUser>(query).FirstOrDefault();
        }

        public dtoEmpresaUser spInsertEmpresa(dtoEmpresaUser param)
        {
            var parameters = new DynamicParameters();
            parameters.Add("nomeUsuario", param.nomeUsuario);
            parameters.Add("nomeEmpresa", param.nomeEmpresa);
            parameters.Add("razaoEmpresa", param.razaoEmpresa);
            parameters.Add("cidadeEmpresa", param.cidadeEmpresa);
            parameters.Add("ramoEmpresa", param.ramoEmpresa);
            parameters.Add("idSetor", param.idSetor);

            return db.Query<dtoEmpresaUser>("sp_cadastraEmpresa", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public dtoEmpresaUser spUpdateEmpresa(dtoEmpresaUser param)
        {
            var parameters = new DynamicParameters();
            parameters.Add("idEmpresa", param.idEmpresa);
            parameters.Add("nomeUsuario", param.nomeUsuario);
            parameters.Add("nomeEmpresa", param.nomeEmpresa);
            parameters.Add("razaoEmpresa", param.razaoEmpresa);
            parameters.Add("cidadeEmpresa", param.cidadeEmpresa);
            parameters.Add("ramoEmpresa", param.ramoEmpresa);
            parameters.Add("idSetor", param.idSetor);

            return db.Query<dtoEmpresaUser>("sp_atualizaEmpresa", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void DeleteAll(int id)
        {
            query = $@"delete usuario where usuario.id in (select empresa.id_usuario from  empresa where empresa.id={id})
                       delete empresa where empresa.id={id}";

            db.Execute(query);
        }
    }
}