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

        public IEnumerable<Cliente> Get()
        {
            using (var dbCliente = new ClienteRep())
            {
                return dbCliente.GetAll().ToList();
            }
        }

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

        public void Delete([FromBody] Cliente cliente)
        {
            if (cliente != null)
            {
                using (var dbCliente = new ClienteRep())
                {
                    dbCliente.Delete(cliente);
                }
            }
        }
    }
}
