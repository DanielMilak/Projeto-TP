﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositorio;

#nullable disable

namespace Projeto_TP.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240410024318_teste8")]
    partial class teste8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Entidades.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Atracao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ValorIngresso")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Evento");
                });
#pragma warning restore 612, 618
        }
    }
}