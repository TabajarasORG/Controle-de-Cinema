using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSessao;
namespace ControleDeCinema.Dominio.ModuloIngresso;

public class Ingresso : EntidadeBase
{
    public string Horario { get; set; }
    
    public Filme Filme { get; set; }
    
    public Sessao Sessao { get; set; }

    public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
    {
        throw new NotImplementedException();
    }

    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}