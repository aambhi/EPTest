﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoTest.Infrastructure.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EPTestEntities : DbContext
    {
        public EPTestEntities()
            : base("name=EPTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BusinessAreaType> BusinessAreaTypes { get; set; }
        public virtual DbSet<BusinessSegmentType> BusinessSegmentTypes { get; set; }
        public virtual DbSet<ClientContact> ClientContacts { get; set; }
        public virtual DbSet<ClientMaster> ClientMasters { get; set; }
    }
}
