using Dominio.Entidades.ClassesPai;
using System.Collections.Generic;

namespace Dominio.Repositorios.ClassesPai
{
    public interface IRepositorio<T> where T : Entidade
    {
        void Salvar(T entidade);
        void Excluir(T entidade);
        T ObterPor(int id);
        List<T> ObterTodos();
    }  
}
