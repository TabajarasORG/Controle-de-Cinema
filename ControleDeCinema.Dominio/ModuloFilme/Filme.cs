using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloFilme;

public class Filme : EntidadeBase
{
    public Filme(string titulo, string duracao, string genero)
    {
        Titulo = titulo;
        Duracao = duracao;
        Genero = genero;
    }

    public String Titulo { get; set; }
    
    public String Duracao { get; set; }

    public String Genero { get; set; }

    
    
    public void AtualizarInformacoes(EntidadeBase entidadeAtualizada)
    {
        Filme filmeAtualizado = (Filme)entidadeAtualizada;

        Titulo = filmeAtualizado.Titulo;
        Duracao = filmeAtualizado.Duracao;
        Genero = filmeAtualizado.Genero;
    }
    
    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}