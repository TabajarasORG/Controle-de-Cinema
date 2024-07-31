using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloFilme;

public class Filme : EntidadeBase
{
    public String Titulo { get; set; }
    
    public String Duracao { get; set; }

    public String Genero { get; set; }
    
    
    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}