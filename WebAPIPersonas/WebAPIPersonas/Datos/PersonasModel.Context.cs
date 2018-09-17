﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIPersonas.Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DbPersonasEntities : DbContext
    {
        public DbPersonasEntities()
            : base("name=DbPersonasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<TipoPersona> TipoPersonas { get; set; }
    
        public virtual int ActualizarPersona(string nombre, string apellido, string telefono, Nullable<int> idTipoPersona, Nullable<int> idPersona)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("apellido", apellido) :
                new ObjectParameter("apellido", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            var idTipoPersonaParameter = idTipoPersona.HasValue ?
                new ObjectParameter("idTipoPersona", idTipoPersona) :
                new ObjectParameter("idTipoPersona", typeof(int));
    
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("idPersona", idPersona) :
                new ObjectParameter("idPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarPersona", nombreParameter, apellidoParameter, telefonoParameter, idTipoPersonaParameter, idPersonaParameter);
        }
    
        public virtual ObjectResult<ConsultarPersonas_Result> ConsultarPersonas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarPersonas_Result>("ConsultarPersonas");
        }
    
        public virtual int EliminarPersona(Nullable<int> idPersona)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("idPersona", idPersona) :
                new ObjectParameter("idPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarPersona", idPersonaParameter);
        }
    
        public virtual int InsertarPersona(string nombre, string apellido, string telefono, Nullable<int> idTipoPersona)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("apellido", apellido) :
                new ObjectParameter("apellido", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            var idTipoPersonaParameter = idTipoPersona.HasValue ?
                new ObjectParameter("idTipoPersona", idTipoPersona) :
                new ObjectParameter("idTipoPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarPersona", nombreParameter, apellidoParameter, telefonoParameter, idTipoPersonaParameter);
        }
    
        public virtual int ActualizarPersona1(string nombre, string apellido, string telefono, Nullable<int> idTipoPersona, Nullable<int> idPersona)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("apellido", apellido) :
                new ObjectParameter("apellido", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            var idTipoPersonaParameter = idTipoPersona.HasValue ?
                new ObjectParameter("idTipoPersona", idTipoPersona) :
                new ObjectParameter("idTipoPersona", typeof(int));
    
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("idPersona", idPersona) :
                new ObjectParameter("idPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ActualizarPersona1", nombreParameter, apellidoParameter, telefonoParameter, idTipoPersonaParameter, idPersonaParameter);
        }
    
        public virtual int InsertarPersona1(string nombre, string apellido, string telefono, Nullable<int> idTipoPersona)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("apellido", apellido) :
                new ObjectParameter("apellido", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            var idTipoPersonaParameter = idTipoPersona.HasValue ?
                new ObjectParameter("idTipoPersona", idTipoPersona) :
                new ObjectParameter("idTipoPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarPersona1", nombreParameter, apellidoParameter, telefonoParameter, idTipoPersonaParameter);
        }
    
        public virtual int EliminarPersona1(Nullable<int> idPersona)
        {
            var idPersonaParameter = idPersona.HasValue ?
                new ObjectParameter("idPersona", idPersona) :
                new ObjectParameter("idPersona", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EliminarPersona1", idPersonaParameter);
        }
    
        public virtual ObjectResult<ConsultarPersonas_Result> ConsultarPersonas1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarPersonas_Result>("ConsultarPersonas1");
        }
    
        public virtual ObjectResult<ConsultarTipoPersonas_Result> ConsultarTipoPersonas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ConsultarTipoPersonas_Result>("ConsultarTipoPersonas");
        }
    
        public virtual ObjectResult<TipoPersona> ConsultarTipoPersonas1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TipoPersona>("ConsultarTipoPersonas1");
        }
    
        public virtual ObjectResult<TipoPersona> ConsultarTipoPersonas1(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TipoPersona>("ConsultarTipoPersonas1", mergeOption);
        }
    }
}