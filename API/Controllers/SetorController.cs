using API.Models;
using API.Repositorio;
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
    public class SetorController : ApiController
    {
        [HttpGet]
        [Route("api/Setor/Get")]
        public IEnumerable<Setor> Get()
        {
            using (var db = new SetorRep())
            {
                return db.GetAll().ToList();
            }
        }

        [HttpGet]
        [Route("api/Setor/GetId")]
        public Setor GetId([FromBody] int Id)
        {
            using (var db = new SetorRep())
            {
                return db.Get(Id);
            }
        }

        public void Post([FromBody] Setor setor)
        {

            if (setor != null)
            {
                using (var db = new SetorRep())
                {
                    db.Insert(setor);
                }
            }
        }

        public void Put([FromBody] Setor setor)
        {
            if (setor != null)
            {
                using (var db = new SetorRep())
                {
                    db.Update(setor);
                }
            }
        }

        public void Delete([FromBody] Setor setor)
        {
            if (setor != null)
            {
                using (var db = new SetorRep())
                {
                    db.Delete(setor);
                }
            }
        }
    }
}
