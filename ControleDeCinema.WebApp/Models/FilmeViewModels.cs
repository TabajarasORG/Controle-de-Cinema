
using System.ComponentModel.DataAnnotations;

namespace ControleDeCinema.WebApp.Models;

public class InserirFilmeViewModel
{
    [Required(ErrorMessage = "Por favor, insira um TITULO")]
    public string Titulo { get; set; }
    
    public string Duracao { get; set; }
    
    public string Genero { get; set; }
}

public class EditarFilmeViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Por favor, preencha o TITULO")]
    public string Titulo { get; set; }
    
    public string Duracao { get; set; }
    
    public string Genero { get; set; }
}

public class ExcluirFilmeViewModel
{
    public int Id { get; set; }
}

public class ListarFilmeViewModel
{
    public int Id { get; set; }
    
    public string Titulo { get; set; }
    
    public string Duracao { get; set; }
    
    public string Genero { get; set; }
}