using Microsoft.EntityFrameworkCore;
using Domain;


namespace Repo
{
    public class RepoContext : DbContext
    {

        //db sets here
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Follows> Follows { get; set; }
        public RepoContext(DbContextOptions<RepoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .HasKey(p => p.Guid);

            modelBuilder.Entity<Post>()
                .HasKey(p => p.Id);
        }
    }
}
