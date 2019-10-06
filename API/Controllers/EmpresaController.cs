using API.Models;
using API.Repositorio.Antena;
using API.Repositorio.Empresa;
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
    public class EmpresaController : ApiController
    {
        [HttpGet]
        [Route("api/Empresa/Get")]
        public IEnumerable<Empresa> Get()
        {
            using (var db = new EmpresaRep())
            {
                return db.GetAll().ToList();
            }
        }

        [HttpGet]
        [Route("api/Empresa/GetId")]
        public Empresa GetId([FromBody] int Id)
        {
            using (var db = new EmpresaRep())
            {
                return db.Get(Id);
            }
        }

        public void Post([FromBody] Empresa empresa)
        {

            if (empresa != null)
            {
                using (var db = new EmpresaRep())
                {
                    db.Insert(empresa);
                }
            }
        }

        public void Put([FromBody] Empresa empresa)
        {
            if (empresa != null)
            {
                using (var db = new EmpresaRep())
                {
                    db.Update(empresa);
                }
            }
        }

        public void Delete([FromUri] int id)
        {
            if (id != 0)
            {
                using (var db = new EmpresaRep())
                {
                    db.Delete(id);
                }
            }
        }
    }
}
