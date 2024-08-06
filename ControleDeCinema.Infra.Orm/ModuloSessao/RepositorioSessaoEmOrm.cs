using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Conpartihado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCinema.Infra.Orm.ModuloSessao;

public class RepositorioSessaoEmOrm : RepositorioBaseEmOrm<Sessao>, IRepositorioSessao
{
    public RepositorioSessaoEmOrm(ControleDeCinemaDbContext dbContext) : base(dbContext)
    {
        
    }

    protected override DbSet<Sessao> ObterRegistros()
    {
        return dbContext.Sessoes;
    }
}