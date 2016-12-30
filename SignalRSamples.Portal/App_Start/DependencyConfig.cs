using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using SignalRSamples.Infrastructure;
using SignalRSamples.Infrastructure.Data.Ef;

namespace SignalRSamples.Portal
{
    public class DependencyConfig
    {
        public static void RegisterDependency()
        {
            var builder = new ContainerBuilder();
            var assemblys =
                AppDomain.CurrentDomain.GetAssemblies().Where(m => m.FullName.StartsWith("SignalRSamples.")).ToArray();
            // Register individual services
            var allServices = FindClassesOfType(typeof(IDependency), assemblys);

            foreach (var type in allServices)
            {
                builder.RegisterType(type).InstancePerLifetimeScope();
            }
            //builder.RegisterAssemblyTypes(assemblys)
            //    .Where(p => baseType.IsAssignableFrom(p) && p != baseType)
            //    .AsImplementedInterfaces()
            //    .InstancePerMatchingLifetimeScope();
            builder.RegisterType<SignalRChatContextFactory>().As<IEfDbContextFactory>().InstancePerRequest();
           var allEntitys = FindClassesOfType(typeof(IEntity), assemblys);
            var tRepository = typeof(EfRepository<>);
            foreach (Type t in allEntitys)
            {
                var t2 = tRepository.MakeGenericType(t);
                builder.RegisterType(t2).AsImplementedInterfaces().WithParameter(ResolvedParameter.ForNamed<IEfDbContextFactory>(""));
            }

            builder.RegisterControllers(assemblys);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true)
        {

            var result = assemblies.SelectMany(s => s.GetTypes())
                .Where(p => assignTypeFrom.IsAssignableFrom(p) && p != assignTypeFrom);
            return result;
        }

    }
}