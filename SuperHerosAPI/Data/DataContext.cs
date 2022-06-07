using Microsoft.EntityFrameworkCore;

namespace SuperHerosAPI.Data
{
    public class DataContext : DbContext
    {
        public DbSet<SuperHero> SuperHeroes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder db)
        {
            base.OnConfiguring(db);
            db.UseSqlServer("Data Source = HASNAINPC\\SQL; Initial Catalog = SuperHero; User Id = sa ; Password = 123");
        }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
           
        }
    }
}
