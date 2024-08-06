using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;

namespace ControleDeCinema.Dominio.ModuloSessao;

public class Sessao : EntidadeBase
{
    public Filme Filme { get; set; }
    
    public Sala Sala { get; set; }
    
    public DateTime HorarioDeInicio { get; set; }

    public Sessao()
    {
        
    }
    public Sessao(Filme filme, Sala sala, DateTime horarioDeInicio)
    {
        Filme = filme;
        Sala = sala;
        HorarioDeInicio = horarioDeInicio;
    }

    public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
    {
        Sessao sessaoAtualizada = (Sessao)registroAtualizado;

        Filme = sessaoAtualizada.Filme;
        Sala = sessaoAtualizada.Sala;
        HorarioDeInicio = sessaoAtualizada.HorarioDeInicio;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Filme == null)
            erros.Add("O campo \"Filme\" é obrigatorio");

        if (Sala == null)
            erros.Add("O campo \"Sala\" é obrigatorio");
        
        if (HorarioDeInicio == null)
            erros.Add("O campo \"Horario\" é obrigatorio");

        return erros;
    }
}