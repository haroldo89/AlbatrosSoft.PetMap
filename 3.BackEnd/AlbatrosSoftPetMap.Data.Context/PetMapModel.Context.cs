﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlbatrosSoftPetMap.Data.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using AlbatrosSoft.PetMap.Domain.Dto;
    
    public partial class PetMapModelContainer : DbContext
    {
        public PetMapModelContainer()
            : base("name=PetMapModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AppUser> AppUserSet { get; set; }
        public virtual DbSet<AppUserRole> AppUserRoleSet { get; set; }
        public virtual DbSet<Contact> ContactSet { get; set; }
        public virtual DbSet<ContactType> ContactTypeSet { get; set; }
        public virtual DbSet<Customer> CustomerSet { get; set; }
        public virtual DbSet<CustomerBillingStatus> CustomerBillingStatusSet { get; set; }
        public virtual DbSet<Dealer> DealerSet { get; set; }
        public virtual DbSet<IdentificationType> IdentificationTypeSet { get; set; }
    }
}