﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SqlServer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DevOnlyEntities : DbContext
    {
        public DevOnlyEntities()
            : base("name=DevOnlyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Loan> Loan { get; set; }
        public DbSet<Loaned> Loaned { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Asset> Asset { get; set; }
    }
}
