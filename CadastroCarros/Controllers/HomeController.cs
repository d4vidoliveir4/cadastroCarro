using CadastroCarros.Models;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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
            var listaCarros = new Home().Listar();
            return View(listaCarros);
        }

        public IActionResult Salvar(Carro carro)
        {
            var retorno = new Home().SalvarEntidade(carro);
            return RedirectToAction("Index");
        }
        
        public IActionResult Excluir(int id)
        {
            var retorno = new Home().DeletarEntidade(id);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            Carro carro = new Home().ObterCarro(id);

            return View("Editar", carro);
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
