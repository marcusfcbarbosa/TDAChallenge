using Microsoft.EntityFrameworkCore;

namespace TDA.Infra.Context
{
    public class ChallengeContext : DbContext {

        public ChallengeContext(){}
        public ChallengeContext(DbContextOptions<ChallengeContext> options)
            : base(options)
        {
        }


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
            base.OnModelCreating(modelBuilder);
        }
    }
        

    
}