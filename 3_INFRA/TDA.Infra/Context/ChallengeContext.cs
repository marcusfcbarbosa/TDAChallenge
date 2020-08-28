using FluentValidator;
using Microsoft.EntityFrameworkCore;
using TDA.Domain.ChallengeContext.Entities;
using TDA.Domain.ValueObjects;

namespace TDA.Infra.Context
{
    public class ChallengeContext : DbContext {

        public ChallengeContext(){}
        public ChallengeContext(DbContextOptions<ChallengeContext> options)
            : base(options)
        {
        }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }

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
    }
}