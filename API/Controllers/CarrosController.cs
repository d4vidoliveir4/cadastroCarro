using Data.NHibernate;
using Data.Repositorios;
using Dominio.Entidades;
using Dominio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        public ICarroRepositorio CarroRepositorio { get; set; }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Carro> ObterTodos()
        {
            var session = FluentNHibernateHelper.OpenSession();

            CarroRepositorio = new CarroRepositorio(session);

            var retorno = CarroRepositorio.ObterTodos();

            session.Close();

            return retorno;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Carro Obter(int id)
        {
            var session = FluentNHibernateHelper.OpenSession();

            CarroRepositorio = new CarroRepositorio(session);

            var retorno = CarroRepositorio.ObterPor(id);

            session.Close();

            return retorno;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public bool Salvar([FromBody] Carro carro)
        {
            try
            {
                var session = FluentNHibernateHelper.OpenSession();
                session.SaveOrUpdate(carro);
                session.Flush();
                session.Close();

                return true;
            }
            catch (Exception ex)
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
                var session = FluentNHibernateHelper.OpenSession();
                CarroRepositorio = new CarroRepositorio(session);
                var reserva = CarroRepositorio.ObterPor(id);
                session.Delete(reserva);
                session.Flush();
                session.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
