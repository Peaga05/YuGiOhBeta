﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YuGiOh01
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class YuGiOhEntity : DbContext
    {
        public YuGiOhEntity()
            : base("name=YuGiOhEntity")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Armadilha> Armadilhas { get; set; }
        public virtual DbSet<Atributo> Atributoes { get; set; }
        public virtual DbSet<Carta> Cartas { get; set; }
        public virtual DbSet<Icone> Icones { get; set; }
        public virtual DbSet<LogUsuario> LogUsuarios { get; set; }
        public virtual DbSet<Magia> Magias { get; set; }
        public virtual DbSet<Monstro> Monstroes { get; set; }
        public virtual DbSet<MonstroPendulo> MonstroPenduloes { get; set; }
        public virtual DbSet<TipoCarta> TipoCartas { get; set; }
        public virtual DbSet<TipoMonstroEfeito> TipoMonstroEfeitoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
