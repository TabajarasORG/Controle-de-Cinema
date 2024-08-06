using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleDeCinema.Infra.Orm.Conpartihado;

public class ControleDeCinemaDbContext : DbContext
{
    public DbSet<Sala> Salas { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
    
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

            modelBuilder.Entity<Sessao>(sessaoBuilder =>
            {
                sessaoBuilder.ToTable("TBSessao");

                sessaoBuilder.Property(s => s.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                sessaoBuilder.HasOne(s => s.Filme)
                    .WithMany()
                    .HasForeignKey("Filme_Id")
                    .HasConstraintName("FK_TBSessao_TBFilme")
                    .IsRequired();

                sessaoBuilder.HasOne(s => s.Sala)
                    .WithMany()
                    .HasForeignKey("Sala_Id")
                    .HasConstraintName("FK_TBSessao_TBSala")
                    .IsRequired();

                sessaoBuilder.Property(s => s.HorarioDeInicio)
                    .IsRequired()
                    .HasColumnType("datetime2");
            });
            
            base.OnModelCreating(modelBuilder);
        }
}