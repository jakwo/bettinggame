using bettinggame.data.Entities;
using Microsoft.EntityFrameworkCore;

namespace bettinggame.data
{
    public class BettingGameContext : DbContext
    {
        public DbSet<Match> Matches { get; set; }

        public DbSet<Tip> Tips { get; set; }

        public BettingGameContext(DbContextOptions<BettingGameContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tip>().HasIndex(x => new { x.User, x.MatchId }).IsUnique();

            modelBuilder.Entity<Tip>().HasOne(x => x.Match).WithMany(x => x.Tips).HasForeignKey(x => x.MatchId);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
