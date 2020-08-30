using FluentValidator;
using Microsoft.EntityFrameworkCore;
using TDA.Domain.ChallengeContext.Entities;
using TDA.Domain.ChallengeContext.Entities.Authentication;
using TDA.Domain.ValueObjects;

namespace TDA.Infra.Context
{
    public class ChallengeContext : DbContext
    {

        public ChallengeContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public ChallengeContext(DbContextOptions<ChallengeContext> options)
            : base(options)
        {
        }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<MedicoEspecialidade> MedicoEspecialidades { get; set; }
        public DbSet<User> Users { get; set; }

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
            EntityMapping(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private void EntityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
                       {
                           entity.ToTable("User").HasKey(e => e.Id);
                           entity.Property(e => e.identifyer).HasDefaultValueSql("lower(hex(randomblob(16)))");
                           entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt");

                           entity.Property(e => e.UserName)
                               .HasMaxLength(100)
                               .HasColumnName("Nome");

                           entity.Property(e => e.PassWord)
                                .HasMaxLength(100)
                                .HasColumnName("PassWord");

                           entity.Property(e => e.Role)
                                .HasMaxLength(100)
                                .HasColumnName("Role");

                       });

            modelBuilder.Entity<Medico>(entity =>
                       {
                           entity.ToTable("Medico").HasKey(e => e.Id);
                           entity.Property(e => e.identifyer).HasDefaultValueSql("lower(hex(randomblob(16)))");
                           entity.Property(e => e.CreatedAt).HasColumnName("CreatedAt");

                           entity.Property(e => e.Nome)
                               .HasMaxLength(100)
                               .HasColumnName("Nome");

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

            //existe uma forma de nao mapear entidades associativas (mas não encontrei, pesquiso depois)
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