using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using PMHBooking.Services;
using PMHBooking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace PMHBooking.App_Start.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(
                Component.For<IIdentity>()
                    .UsingFactoryMethod(() => HttpContext.Current.User.Identity)
                    .LifestylePerWebRequest());

            container.Register(
                Component.For<ISecurityService>()
                    .ImplementedBy<SecurityService>()
                    .LifestyleTransient());


        }
    }
}