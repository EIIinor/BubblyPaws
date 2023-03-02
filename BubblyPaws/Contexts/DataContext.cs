using BubblyPaws.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BubblyPaws.Contexts;

internal class DataContext : DbContext
{
    private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Micke\Desktop\uc-ella\BubblyPaws\BubblyPaws\Contexts\sql_db.mdf;Integrated Security=True;Connect Timeout=30";


    #region constructors
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    #endregion

    #region overrides
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString);
    }

    #endregion

    public DbSet<AddressEntity> Addresses { get; set; } = null!;
    public DbSet<AnimalEntity> Animals { get; set; } = null!;
    public DbSet<BookingEntity> Bookings { get; set; } = null!;
    public DbSet<CustomerEntity> Customers { get; set; } = null!;

}
