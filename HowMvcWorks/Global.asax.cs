using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
namespace HowMvcWorks
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            //Autofac初始化过程
            AutofacManager();
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Myjobs();
        }

        private static void AutofacManager()
        {
            var builder = new ContainerBuilder();
            SetRegisterType(builder);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .AsImplementedInterfaces();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void SetRegisterType(ContainerBuilder builder)
        {
            builder.RegisterType<Models.CustomerService>().As<Models.ICustomer>().InstancePerHttpRequest();
            builder.RegisterType<CRM.Dao.StubOrderItemDalRepository>().As<CRM.IDao.IRepository>().InstancePerHttpRequest();
        }

        private static void Myjobs()
        {
            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = factory.GetScheduler();
            scheduler.Start();
            IJobDetail jobdetail=new JobDetailImpl("jobdetail",typeof(Models.MyJob));
            ISimpleTrigger trigger = new SimpleTriggerImpl("mytrigger", null, DateTime.Now, null, SimpleTriggerImpl.RepeatIndefinitely,/*无限重复*/
                TimeSpan.FromSeconds(10));
            scheduler.ScheduleJob(jobdetail,trigger);
        }
    }
}