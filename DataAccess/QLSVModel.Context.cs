﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class QLSVEntities : DbContext
    {
        public QLSVEntities()
            : base("name=QLSVEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Acount> Acounts { get; set; }
        public virtual DbSet<LoaiSach> LoaiSaches { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
    }
}
