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
        static HttpClient client = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var listaCarros = Listar();
            //Salvar(new Carro { Id = 1, Modelo = "teste2", Montadora = "teste2", Placa = "teste2" });
            return View(listaCarros);
        }


        public IActionResult Salvar(Carro carro)
        {
            var retorno = SalvarEntidade(carro);
            return RedirectToAction("Index");
        }
        
        public IActionResult Excluir(int id)
        {
            var retorno = DeletarEntidade(id);
            return RedirectToAction("Index");
        }

        static async Task<Uri> SalvarEntidade(Carro carro)
        {
            var myContent = JsonConvert.SerializeObject(carro);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync(
                "http://localhost:5000/api/carros", byteContent);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        public IActionResult Editar(int id)
        {
            var response = client.GetAsync("http://localhost:5000/api/carros/"+id);
            response.Wait();
            var result = response.Result;

            var readTask = result.Content.ReadAsStringAsync();
            readTask.Wait();
            var carro = JsonConvert.DeserializeObject<Carro>(readTask.Result);

            return View("Editar", carro);
        }

        static async Task<HttpStatusCode> DeletarEntidade(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("http://localhost:5000/api/carros/" + id);
            return response.StatusCode;
        }

        static List<Carro> Listar()
        {
            var response = client.GetAsync("http://localhost:5000/api/carros");
            response.Wait();
            var result = response.Result;

            var readTask = result.Content.ReadAsStringAsync();
            readTask.Wait();
            var lista = JsonConvert.DeserializeObject<List<Carro>>(readTask.Result);


            return lista.ToList();
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
