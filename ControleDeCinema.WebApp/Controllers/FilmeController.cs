using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.Infra.Orm.ModuloFilme;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers;

public class FilmeController : Controller
{
    [HttpGet]
    public ViewResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(InserirFilmeViewModel InserirFilmeVm)
    {
        if (!ModelState.IsValid)
        {
            return View(InserirFilmeVm);
        }

        var db = new ControleDeCinamaDbContext();
        var repositorioFilme = new RepositorioFilme(db);

        var novoFilme = new Filme(InserirFilmeVm.Titulo, InserirFilmeVm.Duracao, InserirFilmeVm.Genero);
        
        repositorioFilme.Inserir(novoFilme);
        ViewBag.Mensagem = $"O Filme {novoFilme.Titulo} foi cadastrado com sucesso";
        return View("mensagens");
    }
}