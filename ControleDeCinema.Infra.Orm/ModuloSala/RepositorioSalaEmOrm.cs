using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Conpartihado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCinema.Infra.Orm.MosuloSala;

public class RepositorioSalaEmOrm : RepositorioBaseEmOrm<Sala>, IRepositorioSala
{
    public RepositorioSalaEmOrm(ControleDeCinemaDbContext dbContext) : base(dbContext)
    {
        
    }

    protected override DbSet<Sala> ObterRegistros()
    {
        return dbContext.Salas;
    }
}