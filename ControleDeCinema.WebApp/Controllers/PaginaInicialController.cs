using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers;

public class PaginaInicialController : Controller
{
    [HttpGet]
    [Route("/")]
    public ViewResult PaginaInicial()
    {
        return View("PaginaInicial");
    }
}