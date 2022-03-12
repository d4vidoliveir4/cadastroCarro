using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Data.NHibernate
{
    public static class FluentNHibernateHelper
    {
        public static ISession OpenSession()
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=dbCAdastroCarros;Trusted_Connection=True;";

            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CarroMap>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg)
                 .Execute(false, true))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();

        }

    }
}
