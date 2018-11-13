using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApiBase.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private ModelDB db = new ModelDB();

        [HttpGet]
        [Route("validarLogin")]
        public IHttpActionResult validarLogin()
        {

            var identity = Thread.CurrentPrincipal.Identity;
            return Ok(identity.IsAuthenticated);
            //return Ok(identity.Name+"-"+identity.IsAuthenticated);
        }

        [HttpPost]
        //[Route("authenticate")]
        public IHttpActionResult Authenticate(persona persona)
        {

            var person = db.persona.FirstOrDefault(u => u.usuario == persona.usuario && u.clave == persona.clave && u.estado == "1");

            if (person == null)
            {
                //return NotFound();
                return Unauthorized();
            }
            
            var token = TokenGenerator.GenerateTokenJwt(person.usuario, person.perfil.nombre);
            return Ok(token);
        }
        /*       private ModelDB db = new ModelDB();

               // POST api/persona/login
               [AllowAnonymous]
               [ResponseType(typeof(persona))]
               public IHttpActionResult PostAuthenticateUser(persona persona)
               {
                   // I don't validate password here (see TODO below)
                   var person = db.persona.FirstOrDefault(u => u.usuario == persona.usuario && u.clave == persona.clave && u.estado == "1");

                   if (person == null)
                   {
                       return NotFound();
                   }

                   persona usuario = new persona();
                   usuario.nombre = person.nombre;
                   usuario.apellido = person.apellido;
                   if(person.perfil != null) { 
                       usuario.perfil = person.perfil;
                   }
                   usuario.usuario = person.usuario;
                   return Ok(usuario);
               }
       */
    }
}
