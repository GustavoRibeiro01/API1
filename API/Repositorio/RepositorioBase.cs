using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dapper.Contrib.Extensions;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace API.Repositorio
{
    public abstract class RepositorioBase<T> : IDisposable where T : class
    {
        // Database instance
        protected IDbConnection db;

        /// <summary>
        /// Inicializa a instância do banco de dados padrão do App.config
        /// </summary>
        public RepositorioBase()
        {
            // Creating database instance
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["Contexto"].ConnectionString);
        }

        /// <summary>
        /// Inicializa a instância de um banco de dados específico passado por parâmetro
        /// </summary>
        public RepositorioBase(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Retorna uma entidade identificada pelo parâmetro
        /// </summary>
        public virtual T Get(int id)
        {
            return db.Get<T>(id);
        }

        /// <summary>
        /// Retorna uma lista de todas as entidades do contexto do repositório
        /// </summary>
        public virtual IEnumerable<T> GetAll()
        {
            return db.GetAll<T>();
        }

        /// <summary>
        /// Consulta uma query manualmente
        /// </summary>
        public virtual IEnumerable<T> Query(string query)
        {
            return db.Query<T>(query);
        }

        /// <summary>
        /// Executa uma storedProcedure sem parametro
        /// </summary>
        public virtual IEnumerable<T> Stored(string storedName)
        {
            //var p = new DynamicParameters();
            //p.Add("id", "123");
            return db.Query<T>(storedName, null, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Insere um conjunto de entidades no banco de dados
        /// </summary>
        public virtual long Insert(IEnumerable<T> entityList)
        {
            entityList.ToList().ForEach(x => db.Insert(x));

            return entityList.Count();
        }

        /// <summary>
        /// Insere uma entidade no banco de dados
        /// </summary>
        public virtual long Insert(T entity)
        {
            return db.Insert(entity);
        }

        /// <summary>
        /// Atualiza um conjunto de entidades no banco de dados
        /// </summary>
        public virtual bool Update(IEnumerable<T> entityList)
        {
            return db.Update(entityList);
        }

        /// <summary>
        /// Atualiza uma entidade específica no banco de dados
        /// </summary>
        public virtual bool Update(T entity)
        {
            return db.Update(entity);
        }

        /// <summary>
        /// Remove uma entidade específica do banco de dados
        /// </summary>
        public virtual bool Delete(T entity)
        {
            return db.Delete(entity);
        }

        /// <summary>
        /// Remove um conjunto de entidades do banco de dados
        /// </summary>
        public virtual bool Delete(IEnumerable<T> entityList)
        {
            return db.Delete(entityList);
        }

        /// <summary>
        /// Destrói a instância do banco de dados da memória
        /// </summary>
        public void Dispose()
        {
            db.Dispose();
        }
    }
}