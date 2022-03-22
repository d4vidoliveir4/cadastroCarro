using CadastroCarros.Models;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CadastroCarros.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new Home());
        }

        public IActionResult Salvar(Carro carro)
        {
            new Home().SalvarEntidade(carro);
            
            return RedirectToAction("Index");
        }
        
        public IActionResult Excluir(int id)
        {
            new Home().DeletarEntidade(id);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            return View("Editar", new Home(id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
