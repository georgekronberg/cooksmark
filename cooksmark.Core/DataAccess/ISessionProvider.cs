using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace cooksmark.Core.DataAccess
{
    public interface ISessionProvider : IDisposable
    {
        ISession GetSession();
    }
}
