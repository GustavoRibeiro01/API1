using API.Data_Transfer_Object.Antena;
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

        [HttpGet]
        [Route("api/Antena/getDisponiveis")]
        public IEnumerable<Antena> GetAntenasDisp()
        {
            using (var db = new AntenaRep())
            {
                return db.GetDisponiveis();
            }
        }

        [HttpPost]
        [Route("api/AntenaSetor")]
        public void addAntenaSetor([FromBody] dtoAddAntenaSetor dto)
        {
            using (var db = new AntenaRep())
            {
                db.addAntenaSetor(dto.id_setor, dto.id_antena);
            }
        }

        [HttpPost]
        [Route("api/Antena/DeleteAntenaSetor")]
        public void deleteAntenaSetor([FromBody] dtoAddAntenaSetor dto)
        {
            using (var db = new AntenaRep())
            {
                db.deleteAntenaSetor(dto.id_setor, dto.id_antena);
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
