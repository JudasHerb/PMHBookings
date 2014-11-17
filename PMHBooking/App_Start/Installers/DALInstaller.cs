using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PMHBooking.DAL;
using PMHBooking.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace PMHBooking.App_Start.Installers
{
    public class DALInstaller : IWindsorInstaller
    {
        #region IWindsorInstaller Members

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            string path = HostingEnvironment.MapPath(VirtualPathUtility.ToAbsolute("~/App_Data"));

            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifestylePerWebRequest());

        }

        #endregion
    }
}