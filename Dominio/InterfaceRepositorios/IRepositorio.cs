using Dominio.Entidades.ClassesPai;
using System.Collections.Generic;

namespace Dominio.Repositorios
{
    public interface IRepositorio<T> where T : Entidade
    {
        void Salvar(T entidade);
        void Excluir(int id);
        T ObterPor(int id);
        List<T> ObterTodos();
        void FecharSessao();
    }  
}
