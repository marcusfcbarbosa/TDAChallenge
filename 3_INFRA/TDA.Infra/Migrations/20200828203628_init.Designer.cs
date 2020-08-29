﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TDA.Infra.Context;

namespace TDA.Infra.Migrations
{
    [DbContext(typeof(ChallengeContext))]
    [Migration("20200828203628_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("TDA.Domain.ChallengeContext.Entities.Especialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("identifyer")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("TDA.Domain.ChallengeContext.Entities.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Crm")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("identifyer")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("TDA.Domain.ChallengeContext.Entities.MedicoEspecialidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<long>("especialidadeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("especialidadeId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("identifyer")
                        .HasColumnType("TEXT");

                    b.Property<long>("medicoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("medicoId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("especialidadeId1");

                    b.HasIndex("medicoId1");

                    b.ToTable("MedicoEspecialidades");
                });

            modelBuilder.Entity("TDA.Domain.ChallengeContext.Entities.MedicoEspecialidade", b =>
                {
                    b.HasOne("TDA.Domain.ChallengeContext.Entities.Especialidade", "especialidade")
                        .WithMany("medicoEspecialidades")
                        .HasForeignKey("especialidadeId1");

                    b.HasOne("TDA.Domain.ChallengeContext.Entities.Medico", "medico")
                        .WithMany("medicoEspecialidades")
                        .HasForeignKey("medicoId1");
                });
#pragma warning restore 612, 618
        }
    }
}