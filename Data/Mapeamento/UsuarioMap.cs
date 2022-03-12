using Dominio.Entidades;

namespace Data.NHibernate
{
    class CarroMap : Map<Carro>
    {
        public CarroMap()
        {           
            Map(x => x.Modelo);
            Map(x => x.Placa);
            Map(x => x.Montadora);
            Table("Carro");
        }
    }
}