using Microsoft.EntityFrameworkCore;

namespace ShopCom.DataAccess;

public class ShopOutDbContext: DbContext
{
    public DbSet<PurchaseItem> Purchases { get; set; }

    private readonly IDatabasePathService _pathDatabase;

    public ShopOutDbContext(IDatabasePathService pathDatabase)
    {
        _pathDatabase = pathDatabase;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = $"Filename={_pathDatabase.Get("shopdatabase.db")}";
        optionsBuilder.UseSqlite(connectionString);
    }
}

public record PurchaseItem(int ClientId, int ProductId, int Cantidad, decimal Precio) 
{
    public int Id { get; set; }
}
