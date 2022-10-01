using EasyMarket.Domain.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMarket.Infra.Context
{

 public class EasyMarketContext :DbContext
  {
    public EasyMarketContext(DbContextOptions<EasyMarketContext> options) : base(options)
    {

    }
    public DbSet<Users> User { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<Produtos> Produtos { get; set; }
    public DbSet<Fornecedor> Fornecedor { get; set; }
     public DbSet<Entradas> Entradas { get; set; }
    public DbSet<EntradaItems> EntradaItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      //modelBuilder.Entity<Users>().ToTable("User").HasOne<Roles>(u => u.Roles).WithMany(r => r.Users).HasForeignKey(x => x.RolesId);//.HasMany(b => b.Roles).WithOne().HasForeignKey(x => x.RolesId);
      modelBuilder.Entity<Users>().ToTable("User").HasOne<Roles>(x => x.Roles).WithMany(u => u.Users).HasForeignKey(x=>x.RolesId);
      modelBuilder.Entity<Roles>().ToTable("Roles").HasKey(x => x.RolesId);

      modelBuilder.Entity<Produtos>().ToTable("Produtos")
        .HasKey(x => x.Id);
      modelBuilder.Entity<Produtos>().Property(b => b.Id)
         .HasIdentityOptions(startValue: 5);

      modelBuilder.Entity<Fornecedor>().ToTable("Fornecedor").HasKey(x => x.Id);
      modelBuilder.Entity<Fornecedor>().Property(x => x.Id)
        .HasIdentityOptions(startValue: 1);


      modelBuilder.Entity<Entradas>().ToTable("Entradas").HasKey(x => x.Id);
      modelBuilder.Entity<Entradas>().ToTable("Entradas").Property(x => x.Id)
         .HasIdentityOptions(startValue:1);

      modelBuilder.Entity<EntradaItems>().HasOne(x => x.entradas).WithMany(x => x.items).HasForeignKey(x => x.EntradasId);
      modelBuilder.Entity<EntradaItems>().HasOne(x => x.produtos).WithMany(x => x.entradaItens).HasForeignKey(x => x.ProdutoId);
      modelBuilder.Entity<EntradaItems>().ToTable("EntradaItems").HasKey(x => x.Id);
      modelBuilder.Entity<EntradaItems>().Property(x => x.Id).ValueGeneratedOnAdd();
       















    }
  }

  
}
