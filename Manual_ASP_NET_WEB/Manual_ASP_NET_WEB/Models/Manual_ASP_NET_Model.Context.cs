﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Manual_ASP_NET_WEB.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Manual_ASP_NET_DBEntities : DbContext
    {
        public Manual_ASP_NET_DBEntities()
            : base("name=Manual_ASP_NET_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
    }
}
