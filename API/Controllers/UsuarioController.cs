﻿using API.Data_Transfer_Object.Usuario;
using API.Models;
using API.Repositorio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("api/Usuario")]
        public IEnumerable<Usuario> Get()
        {
            using (var dbUsuario = new UsuarioRep())
            {
                return dbUsuario.GetAll().ToList();
            }
        }

        [HttpGet]
        [Route("api/Usuario/{id}")]
        public Usuario GetId([FromUri] Int32 Id)
        {
            using (var db = new UsuarioRep())
            {
                return db.Get(Id);
            }
        }

        [HttpPost]
        [Route("api/Usuario/Login")]
        public DtoLogin Login([FromBody] dtoAuthentication dto)
        {
            using (var db = new UsuarioRep())
            {
                return db.Login(dto.nome, dto.senha);
            }
        }

        public void Post([FromBody] Usuario usuario)
        {

            if (usuario != null)
            {
                using (var dbUsuario = new UsuarioRep())
                {
                    dbUsuario.Insert(usuario);
                }
            }
        }

        public void Put([FromBody] Usuario usuario)
        {
            if (usuario != null)
            {
                using (var dbCliente = new UsuarioRep())
                {
                    dbCliente.Update(usuario);
                }
            }
        }

        public void Delete([FromUri] int id)
        {
            if (id != 0)
            {
                using (var dbCliente = new UsuarioRep())
                {
                    dbCliente.Delete(id);
                }
            }
        }
    }
}
