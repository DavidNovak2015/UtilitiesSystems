using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using VerzovaciSystemDB;
using VerzovaciSystem.Models;
using VerzovaciSystem.Models.Interfaces;
using VerzovaciSystem.Controllers;

namespace VerzovaciSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Autofac
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CompaniesController>().InstancePerLifetimeScope();
            builder.RegisterType<SelectionMaskController>().InstancePerLifetimeScope();
            builder.RegisterType<VersionsFlagController>().InstancePerLifetimeScope();
            builder.RegisterType<VersionsController>().InstancePerLifetimeScope();
            

            builder.RegisterType<DbRepository>().As<IDbRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CompaniesViewModel>().As<ICompaniesViewModel>().InstancePerLifetimeScope();
            builder.RegisterType<VersionsFlagViewModel>().As<IVersionsFlagViewModel>().InstancePerLifetimeScope();

            builder.RegisterType<SelectionMaskViewModel>().As<ISelectionMaskViewModel>().InstancePerLifetimeScope();
            builder.RegisterType<VersionsViewModel>().As<IVersionsViewModel>().InstancePerLifetimeScope();            

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //Autofac
        }
    }
}
