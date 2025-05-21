using Microsoft.EntityFrameworkCore;
using VotumServer.Models;

namespace VotumServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Votation> Votations { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteOption> VoteOptions { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Votation>()
                .HasOne(v => v.Creator)
                .WithMany(u => u.CreatedVotations)
                .HasForeignKey(v => v.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Vote>().ToTable("Votes");
            modelBuilder.Entity<VoteOption>().ToTable("VoteOptions");
            modelBuilder.Entity<Tag>().ToTable("Tags");
        }
    }
}