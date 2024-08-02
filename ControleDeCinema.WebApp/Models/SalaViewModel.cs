using System.ComponentModel.DataAnnotations;

namespace ControleDeCinema.WebApp.Models;

public class InserirSalaViewModel
    {
        [Required(ErrorMessage = "O campo numro é obrigatório!")]
        public string Numero { get; set; }
    
        [Range(
            0,
            int.MaxValue,
            ErrorMessage = "O campo capacidade deve ser maior que zero!"
        )]
        public int Capacidade { get; set; }
    }
    
    public class EditarSalaViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo numro é obrigatório!")]
        public string Numero { get; set; }
    
        [Range(
            0,
            int.MaxValue,
            ErrorMessage = "O campo capacidade deve ser maior que zero!"
        )]
        public int Capacidade { get; set; }
    }
    
    public class ExcluirSalaViewModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Capacidade { get; set; }
    }
    
    public class ListarSalasViewModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Capacidade { get; set; }
    }
    
    public class DetalhesSalasViewModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public int Capacidade { get; set; }
    }
