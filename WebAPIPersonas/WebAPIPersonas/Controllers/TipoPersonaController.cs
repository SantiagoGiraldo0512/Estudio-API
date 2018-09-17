using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIPersonas.Datos;

namespace WebAPIPersonas.Controllers
{
    public class TipoPersonaController : ApiController
    {
        private DbPersonasEntities db = new DbPersonasEntities();

        // GET api/TipoPersona
        public List<TipoPersona> GetTipoPersonas()
        {
            return db.ConsultarTipoPersonas1().ToList();
        }

        


    }
}