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
    public class PersonaController : ApiController
    {
        private DbPersonasEntities db = new DbPersonasEntities();

        // GET api/Persona
        public List<ConsultarPersonas_Result> GetPersonas()
        {
            var lis = db.ConsultarPersonas1().ToList();
            return lis;
        }


        // PUT api/Persona/5
        public Boolean PutPersona(int id, Persona persona)
        {
            
            int registroActualizado = db.ActualizarPersona1(persona.nombre, persona.apellido, persona.telefono,persona.idTipoPersona,id);
            if (registroActualizado<1)
            {
                return false;
            }

                return true;

        }

        // POST api/Persona
        public Boolean PostPersona(Persona persona)
        {
            int registroInsertado = db.InsertarPersona1(persona.nombre, persona.apellido, persona.telefono, persona.idTipoPersona);
            if (registroInsertado<1)
            {
                return false;
            }

                return true;
            
        }

        // DELETE api/Persona/5
        public Boolean DeletePersona(int id)
        {
            int registroEliminado = db.EliminarPersona1(id);
            if (registroEliminado < 1)
            {
                return false;
            }


            return true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaExists(int id)
        {
            return db.Personas.Count(e => e.idPersona == id) > 0;
        }
    }
}