using Autofac;
using Autofac.Integration.Mvc;
using JoseRamos.Agl.Core.Models;
using JoseRamos.Agl.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoseRamos.Agl.Site
{
    public class AutoFacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
            //    .Where(t => t.Name.EndsWith("Provider") && t.Name.EndsWith("Client"))
            //    .AsImplementedInterfaces();

            builder.RegisterType<DataClient>().As<IDataClient>();
            builder.RegisterType<SortingProvider>().As<ISortingProvider>();
            builder.RegisterType<CacheProvider>().As<ICacheProvider>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        

    }
}