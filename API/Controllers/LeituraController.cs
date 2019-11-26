using API.Data_Transfer_Object.Cliente;
using API.Models;
using API.Repositorio.Leitura;
using API.Repositorio.operacaoTags;
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
    public class LeituraController : ApiController
    {

        [HttpGet]
        [Route("api/Leitura")]
        public IEnumerable<Leitura> Get()
        {
            using (var db = new LeituraRep())
            {
                return db.GetAll().ToList();
            }
        }

        [HttpGet]
        [Route("api/Leitura/{id}")]
        public Leitura GetId([FromUri] int id)
        {
            if (id != 0)
            {
                using (var db = new LeituraRep())
                {
                    return db.Get(id);
                }
            }

            return null;
        }

        [HttpGet]
        [Route("api/Leitura/UltimasOperacoes")]
        public IEnumerable<operacaoTags> UltimasOperacoes()
        {
            using (var dbLeitura = new operacaoTagsRep())
            {
                return dbLeitura.Stored("SP_RETORNA_ULTIMAS_OP").ToList();
                //return dbLeitura.Query("select leitura.tag as tag, max(leitura.antena) as antena, max(leitura.operacao) as 'operacao_atual' from leitura group by tag").ToList();
            }
        }

        [HttpGet]
        [Route("api/Leitura/Rastreio")]
        public HttpResponseMessage Rastreio([FromUri] string nome)
        {
            try
            {
                List<DtoRastreio> result;

                using (var dbLeitura = new LeituraRep())
                {
                    result = dbLeitura.Rastreio(nome).ToList();

                }

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
            
        }

        

        [HttpPost]
        [Route("api/Leitura")]
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
