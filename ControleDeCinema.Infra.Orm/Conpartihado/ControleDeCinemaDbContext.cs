using ControleDeCinema.Dominio.ModuloSala;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleDeCinema.Infra.Orm.Conpartihado;

public class ControleDeCinemaDbContext : DbContext
{
    public DbSet<Sala> Salas { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString("SqlServer")!;

        optionsBuilder.UseSqlServer(connectionString);

        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sala>(salaBuilder =>
            {
                salaBuilder.ToTable("TBSala");

                salaBuilder.Property(s => s.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                salaBuilder.Property(s => s.Numero)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                salaBuilder.Property(s => s.Capacidade)
                    .IsRequired()
                    .HasColumnType("int");
            });
            
            base.OnModelCreating(modelBuilder);
        }
}