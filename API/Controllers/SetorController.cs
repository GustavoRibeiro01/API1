using API.Data_Transfer_Object.Setor;
using API.Models;
using API.Repositorio.Setor;
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

        [HttpGet]
        [Route("api/Setor/UltimoSetorTag")]
        public List<DtoUltimoSetorTag> UltimoSetorTag()
        {
            using (var db = new SetorRep())
            {
                return db.UltimoSetorPessoa("UltimoSetorTag").ToList();
            }
        }

        [HttpGet]
        [Route("api/Setor/UltimoSetorPessoa")]
        public List<DtoUltimoSetorTag> UltimoSetorPessoa()
        {
            using (var db = new SetorRep())
            {
                return db.UltimoSetorPessoa("UltimoSetorPessoa").ToList();
            }
        }

        [HttpGet]
        [Route("api/Setor/Rastreio")]
        public List<DtoRastreio> Rastreio(string nome)
        {
            using (var db = new SetorRep())
            {
                return db.Rastreio("Rastreio", nome).ToList();
            }
        }

        [HttpGet]
        [Route("api/Setor/QtdPessoasSetor")]
        public List<DtoQtdPessoasSetor> QtdPessoasSetor()
        {
            using (var db = new SetorRep())
            {
                return db.QtdPessoasSetor("QtdPessoasSetor").ToList();
            }
        }

        [HttpGet]
        [Route("api/Setor/PessoasSetor")]
        public List<DtoPessoasSetor> PessoasSetor(int idSetor)
        {
            using (var db = new SetorRep())
            {
                return db.PessoasSetor("PessoasSetor", idSetor).ToList();
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

        public void Delete([FromUri] int id)
        {
            if (id != 0)
            {
                using (var db = new SetorRep())
                {
                    db.Delete(id);
                }
            }
        }
    }
}
