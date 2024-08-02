using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Conpartihado;
using ControleDeCinema.Infra.Orm.MosuloSala;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers;

public class SalaController : Controller
{
    public ViewResult Listar()
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(db);

        var salas = repositorioSala.SelecionarTodos();

        var listarSalasVm = salas
                .Select(p => 
                    new ListarSalasViewModel
                    {
                        Id = p.Id, 
                        Numero = p.Numero, 
                        Capacidade = p.Capacidade
                    }
                ).ToList();
        return View(listarSalasVm);
    }
    
    public ViewResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(InserirSalaViewModel inserirSalaVm)
    {
        if (!ModelState.IsValid)
            return View(inserirSalaVm);

        var db = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(db);

        var sala = new Sala(inserirSalaVm.Numero, inserirSalaVm.Capacidade);

        repositorioSala.Inserir(sala);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{sala.Id}] foi inserido com sucesso!",
            LinkRedirecionamento =  "/sala/listar"
        };

        HttpContext.Response.StatusCode = 201;
        return View("mensagens", notificacaoVm);
    }
    
    public ViewResult Editar(int id)
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(db);

        var sala = repositorioSala.SelecionarPorId(id);

        var editarSalaVm = new EditarSalaViewModel()
        {
            Id = id,
            Numero = sala.Numero,
            Capacidade = sala.Capacidade
        };

        return View(editarSalaVm);
    }

    [HttpPost]
    public ViewResult Editar(EditarSalaViewModel editarSalaVm)
    {
        if (!ModelState.IsValid)
            return View(editarSalaVm);
        
        var db = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(db);

        var salaOriginal = repositorioSala.SelecionarPorId(editarSalaVm.Id);

        salaOriginal.Numero = editarSalaVm.Numero;
        salaOriginal.Capacidade = editarSalaVm.Capacidade;
        
        repositorioSala.Editar(salaOriginal);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{salaOriginal.Id}] foi editado com sucesso!",
            LinkRedirecionamento =  "/sala/listar"
        };

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Excluir(int id)
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(db);

        var sala = repositorioSala.SelecionarPorId(id);

        var excluirSalaVm = new ExcluirSalaViewModel
        {
            Id = id,
            Numero = sala.Numero,
            Capacidade = sala.Capacidade
        };

        return View(excluirSalaVm);
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult ExcluirConfirmado(ExcluirSalaViewModel excluirSalaVm)
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(db);

        var sala = repositorioSala.SelecionarPorId(excluirSalaVm.Id);

        repositorioSala.Excluir(sala);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{sala.Id}] foi excluído com sucesso!",
            LinkRedirecionamento =  "/sala/listar"
        };

        return View("mensagens", notificacaoVm);
    }

    public ViewResult Detalhes(int id)
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioSala = new RepositorioSalaEmOrm(db);

        var sala = repositorioSala.SelecionarPorId(id);

        var detalhesSalaVm = new DetalhesSalasViewModel()
        {
            Id = id,
            Numero = sala.Numero,
            Capacidade = sala.Capacidade
        };

        return View(detalhesSalaVm);
    }
}