using Data.NHibernate;
using Dominio.Entidades;
using Dominio.Repositorios;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositorios
{
    public class CarroRepositorio : IRepositorio<Carro>
    {
        private readonly ISession _session;

        public CarroRepositorio()
        {
            _session = FluentNHibernateHelper.OpenSession();
        }
        public void Salvar(Carro carro)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(carro);
                tran.Commit();
            }
        }
        private void Excluir(Carro carro)
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

        public void FecharSessao()
        {
            _session.Close();
        }

        public void Excluir(int id)
        {
            var entidade = ObterPor(id);
            Excluir(entidade);
        }
    }
}
