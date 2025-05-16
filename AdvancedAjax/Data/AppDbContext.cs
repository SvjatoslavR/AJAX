namespace AdvancedAjax.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "your_connection_string",
                options => options.EnableRetryOnFailure(
                    maxRetryCount: 5,      // The maximum number of retry attempts
                    maxRetryDelay: TimeSpan.FromSeconds(10), // Maximum time between retries
                    errorNumbersToAdd: null  // Specify which SQL error numbers should trigger a retry (optional)
                )
            );
        }
    }
}
