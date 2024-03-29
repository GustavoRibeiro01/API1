﻿using API.Data_Transfer_Object.Antena;
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
        [Route("api/Setor")]
        public IEnumerable<Setor> Get()
        {
            using (var db = new SetorRep())
            {
                return db.GetAll().ToList();
            }
        }

        [HttpGet]
        [Route("api/Setor/{id}")]
        public Setor GetId([FromUri] int Id)
        {
            using (var db = new SetorRep())
            {
                return db.Get(Id);
            }
        }

        [HttpGet]
        [Route("api/Setor/sp_UltimoSetorTag")]
        public List<DtoUltimoSetorTag> UltimoSetorTag()
        {
            using (var db = new SetorRep())
            {
                return db.UltimoSetorPessoa("sp_UltimoSetorTag").ToList();
            }
        }

        [HttpGet]
        [Route("api/Setor/sp_UltimoSetorPessoa")]
        public List<DtoUltimoSetorTag> UltimoSetorPessoa()
        {
            using (var db = new SetorRep())
            {
                return db.UltimoSetorPessoa("sp_UltimoSetorPessoa").ToList();
            }
        }

        [HttpGet]
        [Route("api/Setor/sp_Rastreio")]
        public List<DtoRastreio> Rastreio(string nome)
        {
            using (var db = new SetorRep())
            {
                return db.Rastreio("sp_Rastreio", nome).ToList();
            }
        }

        [HttpGet]
        [Route("api/Setor/sp_QtdPessoasSetor")]
        public List<DtoQtdPessoasSetor> QtdPessoasSetor()
        {
            using (var db = new SetorRep())
            {
                return db.QtdPessoasSetor("sp_QtdPessoasSetor").ToList();
            }
        }

        [HttpGet]
        [Route("api/Setor/sp_PessoasSetor")]
        public List<DtoPessoasSetor> PessoasSetor(int idSetor)
        {
            using (var db = new SetorRep())
            {
                return db.PessoasSetor("sp_PessoasSetor", idSetor).ToList();
            }
        }

        [HttpGet]
        [Route("api/Setor/sp_FaixaIdadeEvento")]
        public List<DtoFaixaIdade> FaixaIdadeEvento()
        {
            using (var db = new SetorRep())
            {
                return db.FaixaIdadePessoas("sp_FaixaIdadeEvento").ToList();
            }
        }

        [HttpGet]
        [Route("api/Setor/sp_FaixaIdadeSetor")]
        public List<DtoFaixaIdade> FaixaIdadeSetor(int idSetor)
        {
            using (var db = new SetorRep())
            {
                return db.FaixaIdadePessoas("sp_FaixaIdadeSetor", idSetor).ToList();
            }
        }

        [HttpPost]
        [Route("api/Setor")]
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

        [HttpPut]
        [Route("api/Setor")]
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

        [HttpPost]
        [Route("api/Setor/DadosSetor")]
        public DtoDadosSetor DadosSetor([FromBody] int idSetor)
        {
            using (var db = new SetorRep())
            {
                return db.DadosEventoSetor("sp_DadosEvento_Setor", idSetor);
            }
        }

        [HttpGet]
        [Route("api/Setor/DadosGeral")]
        public DtoDadosSetor DadosGeral()
        {
            using (var db = new SetorRep())
            {
                return db.DadosEventoGeral("sp_DadosEvento_Geral");
            }
        }

        [HttpGet]
        [Route("api/Setor/ListaConfig")]
        public IEnumerable<DtoListaConfig> ListaConfig()
        {
            using (var db = new SetorRep())
            {
                return db.GetListaConfig();
            }
        }

        [HttpGet]
        [Route("api/Setor/ListaConfigDetalhe")]
        public IEnumerable<DtoListaConfigDetalhe> ListaConfig(int idSetor)
        {
            using (var db = new SetorRep())
            {
                return db.GetListaConfigDetalhe(idSetor);
            }
        }

        [HttpPost]
        [Route("api/Setor/Deleta")]
        public void DeleteSetor([FromBody] dtoAddAntenaSetor idSetor)
        {
            using (var db = new SetorRep())
            {
                db.DeleteAll(idSetor.id_setor);
            }
        }

        [HttpGet]
        [Route("api/Setor/sp_RankPessoasSetor")]
        public HttpResponseMessage RankPessoasSetor([FromUri] int IdSetor)
        {
            try
            {
                List<DtoRankPessoaSetor> result;

                using (var db = new SetorRep())
                {
                    result = db.RankPessoasSetor(IdSetor).ToList();

                }

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }
    }
}
