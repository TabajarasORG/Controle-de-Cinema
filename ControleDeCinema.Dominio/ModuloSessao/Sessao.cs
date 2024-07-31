using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;

namespace ControleDeCinema.Dominio.ModuloSessao;

public class Sessao : EntidadeBase
{
    public Filme Filme { get; set; }
    
    public Sala Sala { get; set; }
    
    public string HorarioDeInicio { get; set; }
    
    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}