﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DarboLaikoSkaiciavimoSistema.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dlssdb : DbContext
    {
        public dlssdb()
            : base("name=dlssdb")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
    }
}