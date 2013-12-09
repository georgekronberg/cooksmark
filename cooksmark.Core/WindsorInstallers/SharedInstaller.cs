using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using cooksmark.Core.DataAccess;

namespace cooksmark.Core.WindsorInstallers
{
    public class SharedInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                // message bus
                Component.For<IRepository>().ImplementedBy<UserRepository>().LifestylePerWebRequest());
        }
    }
}
