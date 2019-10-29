using API.Models;
using API.Repositorio.Antena;
using API.Repositorio.Grupo_Usuario;
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
    public class GrupoUsuarioController : ApiController
    {
        [HttpGet]
        [Route("api/GrupoUsuario")]
        public IEnumerable<GrupoUsuario> Get()
        {
            using (var db = new GrupoUsuarioRep())
            {
                return db.GetAll().ToList();
            }
        }

        [HttpGet]
        [Route("api/GrupoUsuario/{id}")]
        public GrupoUsuario GetId([FromUri] int Id)
        {
            using (var db = new GrupoUsuarioRep())
            {
                return db.Get(Id);
            }
        }

        public void Post([FromBody] GrupoUsuario grupoUsuario)
        {

            if (grupoUsuario != null)
            {
                using (var db = new GrupoUsuarioRep())
                {
                    db.Insert(grupoUsuario);
                }
            }
        }

        public void Put([FromBody] GrupoUsuario grupoUsuario)
        {
            if (grupoUsuario != null)
            {
                using (var db = new GrupoUsuarioRep())
                {
                    db.Update(grupoUsuario);
                }
            }
        }

        public void Delete([FromUri] int id)
        {
            if (id != 0)
            {
                using (var db = new GrupoUsuarioRep())
                {
                    db.Delete(id);
                }
            }
        }
    }
}
