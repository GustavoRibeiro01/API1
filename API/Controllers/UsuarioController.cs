using API.Models;
using API.Repositorio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        public IEnumerable<Usuario> Get()
        {
            using (var dbUsuario = new UsuarioRep())
            {
                return dbUsuario.GetAll().ToList();
            }
        }

        public void Post([FromBody] Usuario usuario)
        {

            if (usuario != null)
            {
                using (var dbUsuario = new UsuarioRep())
                {
                    dbUsuario.Insert(usuario);
                }
            }
        }

        public void Put([FromBody] Usuario usuario)
        {
            if (usuario != null)
            {
                using (var dbCliente = new UsuarioRep())
                {
                    dbCliente.Update(usuario);
                }
            }
        }

        public void Delete([FromBody] Usuario usuario)
        {
            if (usuario != null)
            {
                using (var dbCliente = new UsuarioRep())
                {
                    dbCliente.Delete(usuario);
                }
            }
        }
    }
}
