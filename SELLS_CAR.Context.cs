﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAR_BD2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SELLS_CAREntities : DbContext
    {
        public SELLS_CAREntities()
            : base("name=SELLS_CAREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CAR> CAR { get; set; }
        public virtual DbSet<SUPPLIER> SUPPLIER { get; set; }
        public virtual DbSet<WHERE_THE_CAR_COMES_FROM> WHERE_THE_CAR_COMES_FROM { get; set; }
        public virtual DbSet<GLOBAL_INFO> GLOBAL_INFO { get; set; }
    }
}
