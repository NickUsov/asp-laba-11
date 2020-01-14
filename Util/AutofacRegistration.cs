using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;
using WebApplication5.DAL;
using System.Web.Mvc;

namespace WebApplication5.Util
{
    public class AutofacRegistration
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<GoodRepository>().As<IRepository<Good>>().WithParameter("context",new ShopContext());
            builder.RegisterType<CategoryRepository>().As<IRepository<Category>>().WithParameter("context", new ShopContext());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}