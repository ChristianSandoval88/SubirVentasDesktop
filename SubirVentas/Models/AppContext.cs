using Microsoft.EntityFrameworkCore;

namespace SubirVentas.Models
{
    public class AppContext:DbContext
    {
        public AppContext(DbContextOptions<AppContext> options):base(options)
        {
                
        }
        public DbSet<PAYMENTS> PAYMENTS { get; set; }
        public DbSet<CATEGORIES> CATEGORIES { get; set; }
        public DbSet<CLOSEDCASH> CLOSEDCASH { get; set; }
        public DbSet<CUSTOMERS> CUSTOMERS { get; set; }
        public DbSet<LOCATIONS> LOCATIONS { get; set; }
        public DbSet<PEOPLE> PEOPLE { get; set; }
        public DbSet<PRODUCTS> PRODUCTS { get; set; }
        public DbSet<PRODUCTS_CAT> PRODUCTS_CAT { get; set; }
        public DbSet<RECEIPTS> RECEIPTS { get; set; }
        public DbSet<ROLES> ROLES { get; set; }
        public DbSet<STOCKCURRENT> STOCKCURRENT { get; set; }
        public DbSet<STOCKDIARY> STOCKDIARY { get; set; }
        public DbSet<TICKETLINES> TICKETLINES { get; set; }
        public DbSet<TICKETS> TICKETS { get; set; }
        public DbSet<APPLICATIONS> APPLICATIONS { get; set; }
    }
}
