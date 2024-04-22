namespace real_estate_asp.Data
{
    using Microsoft.EntityFrameworkCore;
    using real_estate_asp.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Listing> Listings { get; set; }
    }
}
