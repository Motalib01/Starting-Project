using Microsoft.EntityFrameworkCore;
using Starting_Project.Models;

namespace Starting_Project.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        public DbSet<Programs> Programss { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<CandidatePrograms> CandidatePrograms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                "https://starting-db.documents.azure.com:443/",
                "QoI3lTPBxKuVJE89zJGSF3kwLLNo9cBwuaP288quLEfgRCSRcCNutj0p7yhNOwoc6VJL5VFVelPUACDb7VzYnw==",
                "starting-db"
                );
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidatePrograms>()
                .HasKey(cp => new {cp.CandidateId, cp.ProgramId});
            modelBuilder.Entity<CandidatePrograms>()
                .HasOne(cp => cp.candidate)
                .WithMany(c => c.CandidatePrograms)
                .HasForeignKey(cp => cp.CandidateId);
            modelBuilder.Entity<CandidatePrograms>()
                .HasOne(cp => cp.Program)
                .WithMany(p => p.CandidatePrograms)
                .HasForeignKey(cp => cp.ProgramId);



            modelBuilder.Entity<Questions>()
                .ToContainer("Questions")
                .HasPartitionKey(q => q.Id);

            modelBuilder.Entity<Candidate>()
                .ToContainer("Candidates")
                .HasPartitionKey(c => c.Id);

            modelBuilder.Entity<Programs>()
                .ToContainer("Programs")
                .HasPartitionKey(p => p.Id);
        }

    }
    
    
}
