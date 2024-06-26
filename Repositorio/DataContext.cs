﻿using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<EntidadeEvento> Evento { get; set; }
        public DbSet<EntidadeComprador> Comprador { get; set; }
        public DbSet<EntidadeVenda> Venda { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntidadeEvento>().HasKey(p => p.Id);
            modelBuilder.Entity<EntidadeVenda>()
                .HasOne(e => e.Comprador)
                .WithMany()
                .HasForeignKey(e => e.CompradorId);
            modelBuilder.Entity<EntidadeVenda>()
                .HasOne(e => e.Evento)
                .WithMany()
                .HasForeignKey(e => e.EventoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
