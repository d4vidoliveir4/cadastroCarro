using Data.Repositorios;
using Dominio.Entidades;
using Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        public IRepositorio<Carro> CarroRepositorio => new CarroRepositorio();

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Carro> ObterTodos()
        {
            var retorno = CarroRepositorio.ObterTodos();
            CarroRepositorio.FecharSessao();

            return retorno;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Carro Obter(int id)
        {
            var retorno = CarroRepositorio.ObterPor(id);
            CarroRepositorio.FecharSessao();

            return retorno;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public bool Salvar([FromBody] Carro carro)
        {
            try
            {
                CarroRepositorio.Salvar(carro);
                CarroRepositorio.FecharSessao();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public bool Deletar(int id)
        {
            try
            {
                CarroRepositorio.Excluir(id);
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
