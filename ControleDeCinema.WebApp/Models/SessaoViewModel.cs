using System.ComponentModel.DataAnnotations;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleDeCinema.WebApp.Models;


    public class InserirSessaoViewModel
    {
        [Required(ErrorMessage = "O campo Filme é obrigatório!")]
        public int IdFilme { get; set; }
    
        [Required(ErrorMessage = "O campo Sala é obrigatório!")]
        public int IdSala { get; set; }
        
        [Required(ErrorMessage = "O campo do Horario é obrigatório!")]
        public DateTime HorarioDeInicio { get; set; }
        
        public List<SelectListItem> Filmes { get; set; }
        public List<SelectListItem> Salas { get; set; }
    }
    
    public class EditarSessaoViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo Filme é obrigatório!")]
        public int IdFilme { get; set; }
    
        [Required(ErrorMessage = "O campo Sala é obrigatório!")]
        public int IdSala { get; set; }
        
        [Required(ErrorMessage = "O campo do Horario é obrigatório!")]
        public DateTime HorarioDeIncio { get; set; }
        
        public List<SelectListItem> Filmes { get; set; }
        public List<SelectListItem> Salas { get; set; }
    }
    
    public class ExcluirSessaoViewModel
    {
        public int Id { get; set; }
        public Filme Filme { get; set; }
        public Sala Sala { get; set; }
        
        public DateTime HorarioDeInicio { get; set; }
    }
    
    public class ListarSessaoViewModel
    {
        public int Id { get; set; }
        
        public string Filme { get; set; }
        
        public string Sala { get; set; }
        
        public DateTime HorarioDeInicio { get; set; }
    }
    
    public class DetalhesSessaoViewModel
    {
        public int Id { get; set; }
        
        public Filme Filme { get; set; }
        
        public Sala Sala { get; set; }
        
        public DateTime HorarioDeInicio { get; set; }
    }
