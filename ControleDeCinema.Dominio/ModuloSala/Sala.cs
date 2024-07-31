using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloSala;

public class Sala : EntidadeBase
{
    public String Numero { get; set; }
    
    public int Capacidade { get; set; }

    public void OcuparAssentos()
    {
        throw new NotImplementedException();
    }
    
    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}