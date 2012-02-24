using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using System.Web.Mvc;

namespace QuartzMaster.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IController>()
                                .LifestyleTransient(),
                               
                               Classes.FromAssemblyContaining<Base.BaseController>()
                                .BasedOn<IController>()
                                .LifestyleTransient()
                                );
        }
    }
}