using API.Models;
using API.Repositorio.Antena;
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
    public class AntenaController : ApiController
    {
        [HttpGet]
        [Route("api/Antena")]
        public IEnumerable<Antena> Get()
        {
            using (var db = new AntenaRep())
            {
                return db.GetAll().ToList();
            }
        }

        [HttpGet]
        [Route("api/Antena/{id}")]
        public Antena GetId([FromUri] int Id)
        {
            using (var db = new AntenaRep())
            {
                return db.Get(Id);
            }
        }

        public void Post([FromBody] Antena antena)
        {

            if (antena != null)
            {
                using (var db = new AntenaRep())
                {
                    db.Insert(antena);
                }
            }
        }

        public void Put([FromBody] Antena antena)
        {
            if (antena != null)
            {
                using (var db = new AntenaRep())
                {
                    db.Update(antena);
                }
            }
        }

        public void Delete([FromUri] int id)
        {
            if (id != 0)
            {
                using (var db = new AntenaRep())
                {
                    db.Delete(id);
                }
            }
        }
    }
}
