using EasyCruitChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyCruitChallenge.DatabaseContext
{
    /// <summary>
    /// Database context for candidates. Using an in-memory databse.
    /// </summary>
    public class CandidateDatabaseContext : DbContext
    {
        public CandidateDatabaseContext(
            DbContextOptions<CandidateDatabaseContext> dbContextOptions)
            : base(dbContextOptions) { }

        /// <summary>
        /// List of candidates in our in-memory databse.
        /// </summary>
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Let's set primary key.
            modelBuilder.Entity<Candidate>()
                .HasKey(x => x.CandidateId);
        }
    }
}
