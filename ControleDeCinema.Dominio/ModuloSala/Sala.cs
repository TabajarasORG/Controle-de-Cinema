using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloSala;

public class Sala : EntidadeBase
{
    public String Numero { get; set; }
    
    public int Capacidade { get; set; }
    
    public Sala(string numero, int capacidade)
    {
        Numero = numero;
        Capacidade = capacidade;
    }
    public void OcuparAssentos()
    {
        throw new NotImplementedException();
    }

    public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
    {
        Sala salaAtualizada = (Sala)registroAtualizado;

        Numero = salaAtualizada.Numero;
        Capacidade = salaAtualizada.Capacidade;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrEmpty(Numero.Trim()))
            erros.Add("O campo \"Numero\" é obrigatorio");

        if (Capacidade == null)
            erros.Add("O campo \"Capacidade\" é obrigatorio");

        return erros;
    }
}