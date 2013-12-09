using System.Collections.Generic;
using System.Data;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace cooksmark.Core.DataAccess
{
    public class SimpleSessionProvider : ISessionProvider
    {

        //private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType);

        private ISessionFactory _factory = null;

        // interfaces

        #region IDisposable Members

        public void Dispose()
        {
            if (_factory != null && !_factory.IsClosed)
            {
                _factory.Close();
                _factory = null;
            }
        }

        #endregion

        #region ISimpleSessionProvider Members

        public ISession GetSession()
        {
            ISession session = _factory.OpenSession();
            return session;
        }

        #endregion

        // public methods

        public void Configure(string connectionStringsKey, IEnumerable<Assembly> mappingAssemblies)
        {
            var fluentConfiguration = Fluently.
                Configure()
/*                .Cache(_ => _
                    .UseSecondLevelCache()
                    .ProviderClass<ConfigurationBasedCacheProvider>())
                    .ExposeConfiguration(cfg => cfg.SessionFactory().Caching.WithDefaultExpiration(900))*/
                .Database(
                    MsSqlConfiguration.
                        MsSql2008.
                        Driver<Sql2008ClientDriver>().
                        Dialect<MsSql2012Dialect>().
                        IsolationLevel(IsolationLevel.ReadUncommitted).
                        ConnectionString(c => c.FromConnectionStringWithKey(connectionStringsKey)));

            foreach (Assembly assembly in mappingAssemblies)
            {
                Assembly localAssembly = assembly;
                fluentConfiguration.Mappings(m => m.HbmMappings.AddFromAssembly(localAssembly));
                fluentConfiguration.Mappings(m => m.FluentMappings.AddFromAssembly(localAssembly));
            }

            _factory = fluentConfiguration.BuildSessionFactory();
        }

    }
}