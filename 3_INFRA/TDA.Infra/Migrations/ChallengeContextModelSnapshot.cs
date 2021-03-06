﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TDA.Infra.Context;

namespace TDA.Infra.Migrations
{
    [DbContext(typeof(ChallengeContext))]
    partial class ChallengeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("TDA.Domain.ChallengeContext.Entities.Authentication.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("PassWord")
                        .HasColumnName("PassWord")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("Role")
                        .HasColumnName("Role")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .HasColumnName("Nome")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("identifyer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("lower(hex(randomblob(16)))");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TDA.Domain.ChallengeContext.Entities.Especialidade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnName("Descricao")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("identifyer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("lower(hex(randomblob(16)))");

                    b.HasKey("Id");

                    b.ToTable("Especialidade");
                });

            modelBuilder.Entity("TDA.Domain.ChallengeContext.Entities.Medico", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("Cpf")
                        .HasColumnType("TEXT")
                        .HasMaxLength(11);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnName("Crm")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .HasColumnName("Nome")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("identifyer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("lower(hex(randomblob(16)))");

                    b.HasKey("Id");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("TDA.Domain.ChallengeContext.Entities.MedicoEspecialidade", b =>
                {
                    b.Property<long>("medicoId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("especialidadeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<long>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("identifyer")
                        .HasColumnType("TEXT");

                    b.HasKey("medicoId", "especialidadeId");

                    b.HasIndex("especialidadeId");

                    b.ToTable("MedicoEspecialidade");
                });

            modelBuilder.Entity("TDA.Domain.ChallengeContext.Entities.MedicoEspecialidade", b =>
                {
                    b.HasOne("TDA.Domain.ChallengeContext.Entities.Especialidade", "especialidade")
                        .WithMany("medicoEspecialidades")
                        .HasForeignKey("especialidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TDA.Domain.ChallengeContext.Entities.Medico", "medico")
                        .WithMany("medicoEspecialidades")
                        .HasForeignKey("medicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
