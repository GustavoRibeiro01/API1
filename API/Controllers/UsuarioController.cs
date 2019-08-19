using API.Models;
using API.Repositorio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
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
    }
}
