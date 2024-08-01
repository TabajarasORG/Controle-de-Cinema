using System.ComponentModel.DataAnnotations;

namespace ControleDeCinema.WebApp.Models;

public class InserirFilmeViewModel
{
    [Required(ErrorMessage = "Por favor, insira um TITULO")]
    public string Titulo { get; set; }
    
    public string Duracao { get; set; }
    
    public string Genero { get; set; }
}