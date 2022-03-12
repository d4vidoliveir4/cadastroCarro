using Dominio.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CadastroCarros.Models
{
    public class Home
    {
        static HttpClient client = new HttpClient();

        public async Task<Uri> SalvarEntidade(Carro carro)
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

        public async Task<HttpStatusCode> DeletarEntidade(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync("http://localhost:5000/api/carros/" + id);
            return response.StatusCode;
        }

        public Carro ObterCarro(int id)
        {
            var response = client.GetAsync("http://localhost:5000/api/carros/" + id);
            response.Wait();
            var result = response.Result;

            var readTask = result.Content.ReadAsStringAsync();
            readTask.Wait();
            var carro = JsonConvert.DeserializeObject<Carro>(readTask.Result);
            return carro;
        }


        public List<Carro> Listar()
        {
            var response = client.GetAsync("http://localhost:5000/api/carros");
            response.Wait();
            var result = response.Result;

            var readTask = result.Content.ReadAsStringAsync();
            readTask.Wait();
            var lista = JsonConvert.DeserializeObject<List<Carro>>(readTask.Result);


            return lista.ToList();
        }

    }
}
