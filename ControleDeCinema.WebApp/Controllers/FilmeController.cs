﻿using ControleDeCinema.Dominio.ModuloFilme;
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

    [HttpGet]
    public ViewResult Editar(int id)
    {
        var db = new ControleDeCinamaDbContext();
        var repositorioFilme = new RepositorioFilme(db);

        var filme = repositorioFilme.SelecionarPorId(id);

        var editarFilmeVm = new EditarFilmeViewModel()
        {
                Id = filme.Id,
                Titulo = filme.Titulo,
                Duracao = filme.Duracao,
                Genero = filme.Genero
        };
        return View(editarFilmeVm);
    }

    [HttpPost]
    public ViewResult Editar(EditarFilmeViewModel editarFilmeVm)
    {
        if (!ModelState.IsValid)
            return View(editarFilmeVm);
        
        var db = new ControleDeCinamaDbContext();
        var repositorioFilme = new RepositorioFilme(db);

        var filmeOriginal = repositorioFilme.SelecionarPorId(editarFilmeVm.Id);

        var filmeEditado = new Filme(editarFilmeVm.Titulo, editarFilmeVm.Duracao, editarFilmeVm.Genero);

        repositorioFilme.Editar(filmeOriginal,filmeEditado);
        
        ViewBag.Mensagem = $"O Filme {filmeOriginal.Id} foi editado com sucesso";
        
        return View("mensagens");
    }

    [HttpGet]
    public ViewResult Excluir(int id)
    {
        var db = new ControleDeCinamaDbContext();
        var repositorioFilme = new RepositorioFilme(db);

        var filme = repositorioFilme.SelecionarPorId(id);

        var excluirFilmeVm = new ExcluirFilmeViewModel()
        {
            Id = filme.Id,
            Titulo = filme.Titulo
        };
        return View(excluirFilmeVm);
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult Excluir(ExcluirFilmeViewModel excluirFilmeViewModel)
    {
        var db = new ControleDeCinamaDbContext();
        var repositorioFilme = new RepositorioFilme(db);

       var filme =  repositorioFilme.SelecionarPorId(excluirFilmeViewModel.Id);

       repositorioFilme.Excluir(filme);

       ViewBag.Mensagem = $"O Filme {excluirFilmeViewModel.Titulo} foi excluido com sucesso";
        
        return View("mensagens");
    }

    [HttpGet]
    public ViewResult Listar()
    {
        var db = new ControleDeCinamaDbContext();
        var repositorioFilme = new RepositorioFilme(db);

        var filmes = repositorioFilme.SelecionarTodos();

        var filmeViewModel = filmes.Select(f => new ListarFilmeViewModel
            {
                Id = f.Id,
                Titulo = f.Titulo,
                Duracao = f.Duracao,
                Genero = f.Genero
                
            });

        return View(filmeViewModel);
    }

    [HttpGet]
    public ViewResult Detalhes(DetalhesFilmeViewModel detalhesFilmeViewModel)
    {
        var db = new ControleDeCinamaDbContext();
        var repositorioFilme = new RepositorioFilme(db);

        var filme = repositorioFilme.SelecionarPorId(detalhesFilmeViewModel.Id);

        var filmeViewModel = new DetalhesFilmeViewModel
        {
            Id = filme.Id,
            Titulo = filme.Titulo,
            Duracao = filme.Duracao,
            Genero = filme.Genero
        };
        
        return View(filmeViewModel);
    }
}