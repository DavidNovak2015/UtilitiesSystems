﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VerzovaciSystemDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntityFramework : DbContext
    {
        public EntityFramework()
            : base("name=OracleConnectionString")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EX_COMPANY_TYPE> EX_COMPANY_TYPE { get; set; }
        public virtual DbSet<VERSION_COMPANY> VERSION_COMPANY { get; set; }
    }
}
