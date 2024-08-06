using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Conpartihado;
using ControleDeCinema.Infra.Orm.ModuloSessao;
using ControleDeCinema.Infra.Orm.MosuloSala;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleDeCinema.WebApp.Controllers;

public class SessaoController : Controller
{
    public ViewResult Listar()
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioSessao = new RepositorioSessaoEmOrm(db);

        var sessoes = repositorioSessao.SelecionarTodos();

        var listarSessoesVm = sessoes
            .Select(p => 
                new ListarSessaoViewModel
                {
                    Id = p.Id, 
                    Filme = p.Filme.Titulo, 
                    Sala = p.Sala.Numero,
                    HorarioDeInicio = p.HorarioDeInicio
                }
            ).ToList();
        return View(listarSessoesVm);
    }
    
    public ViewResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(InserirSessaoViewModel inserirSessaoVm)
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioSessao = new RepositorioSessaoEmOrm(db);
        var repositorioSala = new RepositorioSalaEmOrm(db);

        if (!ModelState.IsValid)
            return View(inserirSessaoVm);


        var SalaSelecionada = repositorioSala.SelecionarPorId(inserirSessaoVm.IdSala);
        var sessao = new Sessao(null, SalaSelecionada, inserirSessaoVm.HorarioDeInicio );

        repositorioSessao.Inserir(sessao);

        var notificacaoVm = new NotificacaoViewModel
        {
            Mensagem = $"O registro com o ID [{sessao.Id}] foi inserido com sucesso!",
            LinkRedirecionamento =  "/sessao/listar"
        };

        HttpContext.Response.StatusCode = 201;
        return View("mensagens", notificacaoVm);
    }

    /*public ViewResult Editar(int id)
    {
        var db = new ControleDeCinemaDbContext();
        var repositorioSessao = new RepositorioSessaoEmOrm(db);

        var sessao = repositorioSessao.SelecionarPorId(id);

        var editarSalaVm = new EditarSessaoViewModel()
        {
            Id = id,
            Filme = sessao.Filme,
            Sala = sessao.Sala,
            HorarioDeIncio = sessao.HorarioDeInicio
        };

        return View(editarSalaVm);
    }

    [HttpPost]
    public ViewResult Editar(EditarSalaViewModel editarSalaVm)
    {
        if (!ModelState.IsValid)
            return View(editarSessaoVm);

        var db = new ControleDeCinemaDbContext();
        var repositorioSessao = new RepositorioSessaoEmOrm(db);

        var salaOriginal = repositorioSessao.SelecionarPorId(editarSalaVm.Id);

        salaOriginal.Numero = editarSalaVm.Numero;
        salaOriginal.Capacidade = editarSalaVm.Capacidade;

        repositorioSessao.Editar(salaOriginal);

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
        var repositorioSessao = new RepositorioSessaoEmOrm(db);

        var sala = repositorioSessao.SelecionarPorId(id);

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
        var repositorioSessao = new RepositorioSessaoEmOrm(db);

        var sala = repositorioSessao.SelecionarPorId(excluirSalaVm.Id);

        repositorioSessao.Excluir(sala);

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
        var repositorioSessao = new RepositorioSessaoEmOrm(db);

        var sala = repositorioSessao.SelecionarPorId(id);

        var detalhesSalaVm = new DetalhesSalasViewModel()
        {
            Id = id,
            Numero = sala.Numero,
            Capacidade = sala.Capacidade
        };

        return View(detalhesSalaVm);
    }*/
}