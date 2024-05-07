using Microsoft.EntityFrameworkCore ;
using WebApplication2.Models;

namespace WebApplication2.Data;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<VendingMachine> VendingMachines { get; set; }
    public DbSet<OwnerMachine> OwnerMachines { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Owner> Owners { get; set; }
}