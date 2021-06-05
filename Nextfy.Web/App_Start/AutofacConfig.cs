using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using Nexify.DataAccess.Repository;
namespace Nextfy.Web.App_Start
{
    public class AutofacConfig
    {
        public static void Register() {


            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            string dbPath = System.Web.HttpContext.Current.Server.MapPath("~/Dbdata/User.sqlite");
            string cnStr = "data source=" + dbPath;

            builder.RegisterType<UserRepository>().As<IUerRepository>().WithParameter("cnStr", cnStr).InstancePerHttpRequest();


            IContainer container = builder.Build();

            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}