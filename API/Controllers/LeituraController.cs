using API.Models;
using API.Repositorio.Leitura;
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
    public class LeituraController : ApiController
    {

        [HttpGet]
        [Route("api/Leitura/Get")]
        public IEnumerable<Leitura> Get()
        {
            using (var db = new LeituraRep())
            {
                return db.GetAll().ToList();
            }
        }

        [HttpGet]
        [Route("api/Leitura/GetId")]
        public Leitura GetId([FromBody] int Id)
        {
            using (var db = new LeituraRep())
            {
                return db.Get(Id);
            }
        }

        public void Post([FromBody] Leitura leitura)
        {

            if (leitura != null)
            {
                using (var db = new LeituraRep())
                {
                    db.Insert(leitura);
                }
            }
        }

        public void Put([FromBody] Leitura leitura)
        {
            if (leitura != null)
            {
                using (var db = new LeituraRep())
                {
                    db.Update(leitura);
                }
            }
        }

        public void Delete([FromUri] int id)
        {
            if (id != 0)
            {
                using (var db = new LeituraRep())
                {
                    db.Delete(id);
                }
            }
        }
    }
}
