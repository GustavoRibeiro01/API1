using API.Models;
using API.Repositorio.Cliente;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClienteController : ApiController
    {

        [HttpGet]
        [Route("api/Cliente")]
        public IEnumerable<Cliente> Get()
        {
            using (var dbCliente = new ClienteRep())
            {
                return dbCliente.GetAll().ToList();
            }
        }

        [HttpGet]
        [Route("api/Cliente/{id}")]
        public Cliente Get([FromUri]int id)
        {
            if (id != 0)
            {
                using (var db = new ClienteRep())
                {
                    return db.Get(id);
                }
            }

            return null;
        }

        [HttpGet]
        [Route("api/Cliente/GetFilter")]
        public IEnumerable<Cliente> GetFilter([FromUri]int id = 0, string nome = null, string cpf = null, string sexo = null, string profissao = null)
        {

            using (var db = new ClienteRep())
            {
                List<Cliente> Clientes = db.GetFilter(id, nome, cpf, sexo, profissao).ToList();

                // if (Clientes.Any())
                return Clientes.ToList();

                //return db.GetAll();
            }

        }

        [HttpPost]
        [Route("api/Cliente/Gravar")]
        public void Post([FromBody] Cliente cliente)
        {

            if (cliente != null)
            {
                using (var dbCliente = new ClienteRep())
                {
                    dbCliente.Insert(cliente);
                }
            }
        }

        [HttpPost]
        [Route("api/Cliente/Alterar")]
        public void Put([FromBody] Cliente cliente)
        {
            if (cliente != null)
            {
                using (var dbCliente = new ClienteRep())
                {
                    dbCliente.Update(cliente);
                }
            }
        }
        [HttpDelete]
        [Route("api/Cliente/Deletar")]
        public void Delete([FromUri] int id)
        {
            if (id != 0)
            {
                using (var dbCliente = new ClienteRep())
                {
                    dbCliente.Delete(id);
                }
            }
        }
    }
}
