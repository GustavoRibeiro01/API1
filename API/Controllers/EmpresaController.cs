using API.Data_Transfer_Object.Empresa;
using API.Models;
using API.Repositorio.Antena;
using API.Repositorio.Empresa;
using Newtonsoft.Json.Linq;
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
        [Route("api/Empresa")]
        public IEnumerable<Empresa> Get()
        {
            using (var db = new EmpresaRep())
            {
                return db.GetAll().ToList();
            }
        }

        [HttpGet]
        [Route("api/Empresa/getEmpresaUser")]
        public dtoEmpresaUser Gett([FromUri] int Id)
        {
            using (var db = new EmpresaRep())
            {
                return db.GetListaEmpresaUser(Id);
            }
        }

        [HttpGet]
        [Route("api/Empresa/GetEmpresaUsuario")]
        public Empresa GetEmpresaUsuario([FromUri] int IdUsuario)
        {
            using (var db = new EmpresaRep())
            {
                return db.GetEmpresaUsuario(IdUsuario);
            }
        }

        [HttpPost]
        [Route("api/Empresa/GravarEmpresaDto")]
        public void Post([FromBody] DtoEmpresa empresa)
        {

            if (empresa != null)
            {
                using (var db = new EmpresaRep())
                {
                    db.GravarEmpresa(empresa);
                }
            }
        }

        [HttpPost]
        [Route("api/Empresa/GravarEmpresa")]
        public void Post([FromBody] JObject obj)
        {

            if (obj != null)
            {
                Usuario usuario = obj["usuario"].ToObject<Usuario>();
                Empresa empresa = obj["empresa"].ToObject<Empresa>();
                
                if(usuario != null && empresa !=null)
                {
                    using (var db = new EmpresaRep())
                    {
                        db.GravarEmpresa(usuario, empresa);
                    }

                }
                
            }
        }

        [HttpPut]
        [Route("api/Empresa/UpdateEmpresaDto")]
        public void UpdateEmpresaDto([FromBody] DtoEmpresa empresa)
        {

            if (empresa != null)
            {
                using (var db = new EmpresaRep())
                {
                    db.UpdateEmpresa(empresa);
                }
            }
        }

        [HttpPut]
        [Route("api/Empresa/UpdateEmpresa")]
        public void UpdateEmpresa([FromBody] JObject obj)
        {

            if (obj != null)
            {
                Usuario usuario = obj["usuario"].ToObject<Usuario>();
                Empresa empresa = obj["empresa"].ToObject<Empresa>();

                if (usuario != null && empresa != null)
                {
                    using (var db = new EmpresaRep())
                    {
                        db.UpdateEmpresa(usuario, empresa);
                    }

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

        [HttpPut]
        [Route("api/Empresa/spUpdate")]
        public void spUpdate([FromBody] dtoEmpresaUser empresa)
        {

            if (empresa != null)
            {
                using (var db = new EmpresaRep())
                {
                    db.spUpdateEmpresa(empresa);
                }
            }
        }
    }
}
