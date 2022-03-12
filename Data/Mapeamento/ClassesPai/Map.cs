using Dominio.Entidades.ClassesPai;
using FluentNHibernate.Mapping;

namespace Data.NHibernate
{
    class Map<T> : ClassMap<T>
        where T : Entidade
    {
        public Map()
        {
            Id(x => x.Id);
        }
    }
}