using Dominio.Entidades;
using Dominio.Repositorios;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositorios
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private readonly ISession _session;

        public CarroRepositorio(ISession session)
        {
            _session = session;
        }
        public void Salvar(Carro carro)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(carro);
                tran.Commit();
            }
        }
        public void Excluir(Carro carro)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(carro);
                tran.Commit();
            }
        }

        public Carro ObterPor(int id)
        {
            return _session.Get<Carro>(id);
        }

        public List<Carro> ObterTodos()
        {
            return _session.Query<Carro>().ToList();
        }

    }
}
