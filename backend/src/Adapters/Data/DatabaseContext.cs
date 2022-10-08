using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        this.Database.EnsureCreated();
    }
    public virtual DbSet<Sale> Sales => Set<Sale>();
}
