[assembly: WebActivator.PreApplicationStartMethod(typeof(ReportSpace.CustomerDashboard.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(ReportSpace.CustomerDashboard.Web.App_Start.NinjectWebCommon), "Stop")]

namespace ReportSpace.CustomerDashboard.Web.App_Start
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    using ReportSpace.CustomerDashboard.Core;
    using ReportSpace.CustomerDashboard.Web.Factories;
    using ReportSpace.CustomerDashboard.Web.Filters;
    using ReportSpace.CustomerDashboard.Web.Services;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Mvc.FilterBindingSyntax;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            try
            {
                DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
                DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
                bootstrapper.Initialize(CreateKernel);
            }
            catch (Exception x)
            {
                return;
            }
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IReportsService>().To<ReportsService>();
            kernel.Bind<IReportParametersService>().To<ReportParameterService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IReportParameterFactory>().To<ReportParameterFactory>();
            kernel.Bind<IReportsContext>().To<ReportsContext>().InRequestScope();
            kernel.Bind<IUserContext>().To<UsersContext>().InRequestScope();
            kernel.BindFilter<SetUserLogo>(FilterScope.Controller, 0);
        }        
    }
}
