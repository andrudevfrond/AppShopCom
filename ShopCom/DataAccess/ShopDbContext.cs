using Microsoft.EntityFrameworkCore;

namespace ShopCom.DataAccess;

public class ShopDbContext :DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ShopComputer");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category(1, "Electronicos"),
            new Category(2, "Computadoras"),
            new Category(3, "Telefonos Moviles"),
            new Category(4,"Dispositivos de escritorio"),
            new Category(5,"Microfonos y audio"),
            new Category(6,"Artefactos del hogar"),
            new Category(7,"Juguetes y juegos")
        );

        modelBuilder.Entity<Product>().HasData(
            new Product(1, "Radio digital", "Es un radio de banda ancha", 100, 1),
            new Product(2, "Reloj electronico honda", "Reloj de muy buena sincronizacion", 50, 1),
            new Product(3, "Laptop HP", "Laptop para escritorio y manejo de office", 850, 2),
            new Product(4, "Laptop Acer", "Laptop para juegos avanzados de memoria", 1300, 2),
            new Product(5, "Macbook Apple", "Makbook para trasnporte de gran capacidad", 1900, 2),
            new Product(6, "Samsung Galaxy 2", "Telefono con 5G y media", 2000, 3),
            new Product(7, "Iphone 11", "Telefono con  gran capacidad y seguridad", 2200, 3)
        );

        modelBuilder.Entity<Client>().HasData(
            new Client(1, "Jose Martinez", "Av. La plaza 456"),
            new Client(2, "Manuel Porras", "Av. La plaza 482"),
            new Client(3, "Eva Jimenez", "Av. La plaza 785"),
            new Client(4, "Diana Galindo", "Av. La plaza 365"),
            new Client(5, "Andres Rodriguez", "Av. La plaza 598"),
            new Client(6, "Emily Lopez", "Av. La plaza 254")
        );

        base.OnModelCreating(modelBuilder);
    }
}

public record Category (int Id, string Name);
public record Product(int Id, string Name, string Description, decimal Price, int CategoryId) { 
    public Category Category { get; set; }
};

public record Client (int Id, string Name, string Adress);
