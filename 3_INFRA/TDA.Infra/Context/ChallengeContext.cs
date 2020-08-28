using FluentValidator;
using Microsoft.EntityFrameworkCore;
using TDA.Domain.ChallengeContext.Entities;
using TDA.Domain.ValueObjects;

namespace TDA.Infra.Context
{
    public class ChallengeContext : DbContext
    {

        public ChallengeContext() { }
        public ChallengeContext(DbContextOptions<ChallengeContext> options)
            : base(options)
        {
        }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }

        public DbSet<MedicoEspecialidade> MedicoEspecialidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=TDAChallenge.DB");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChallengeContext).Assembly);
            modelBuilder.Ignore<Notifiable>();
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Email>();

            base.OnModelCreating(modelBuilder);
        }
        private void EntityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>(entity =>
                       {
                           entity.ToTable("Medico").HasKey(e => e.Id);
                           entity.Property(e => e.identifyer).HasDefaultValueSql("lower(hex(randomblob(16)))");
                           entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt");

                           entity.Property(e => e.Nome)
                               .HasMaxLength(100)
                               .HasColumnName("Nome");

                           entity.Property(e => e.Email)
                               .IsRequired()
                               .HasMaxLength(20).
                               HasColumnName("Email");

                           entity.Property(e => e.Cpf)
                                .IsRequired()
                                .HasMaxLength(11).
                                HasColumnName("Cpf");

                           entity.Property(e => e.Crm)
                                        .IsRequired()
                                        .HasMaxLength(50).
                                        HasColumnName("Crm");
                       });

            modelBuilder.Entity<Especialidade>(entity =>
               {
                   entity.ToTable("Especialidade").HasKey(e => e.Id);
                   entity.Property(e => e.identifyer).HasDefaultValueSql("lower(hex(randomblob(16)))");
                   entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt");

                   entity.Property(e => e.Descricao)
                       .HasMaxLength(100)
                       .HasColumnName("Descricao");
               });

            modelBuilder.Entity<MedicoEspecialidade>(entity =>
            {
                entity.ToTable("MedicoEspecialidade").HasKey(me => new { me.medicoId, me.especialidadeId });

                entity.HasOne(m => m.medico)
                                   .WithMany(me => me.medicoEspecialidades)
                                   .HasForeignKey(me => me.medicoId);
                entity.HasOne(e => e.especialidade)
                                   .WithMany(me => me.medicoEspecialidades)
                                   .HasForeignKey(me => me.especialidadeId);
            });

        }
    }
}