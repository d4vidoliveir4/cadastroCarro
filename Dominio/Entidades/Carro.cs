using Dominio.Entidades.ClassesPai;

namespace Dominio.Entidades
{
    public class Carro : Entidade
    {
        public virtual string Placa { get; set; }
        public virtual string Montadora { get; set; }
        public virtual string Modelo { get; set; }
    }
}