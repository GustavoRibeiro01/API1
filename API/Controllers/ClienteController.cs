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

namespace API.Controllers
{
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
    }
}
