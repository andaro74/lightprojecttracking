[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TeamProjectWeb.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TeamProjectWeb.App_Start.NinjectWebCommon), "Stop")]

namespace TeamProjectWeb.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using TeamProject.Business.Contracts;
    using TeamProject.Business.Common;
    using TeamProject.Business;
    using TeamProject.Business.Managers;
    using TeamProject.Data.Contracts;
    using TeamProject.Data;
    using TeamProject.Data.Data_Repositories;
    using TeamProject.Business.Business_Engines;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
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
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IContactRepository>().To<ContactRepository>();
            kernel.Bind<IContactService>().To<ContactManager>();
            kernel.Bind<IContactEngine>().To<ContactEngine>();

            kernel.Bind<IProjectRepository>().To<ProjectRepository>();
            kernel.Bind<ITeamProjectEngine>().To<TeamProjectEngine>();
            kernel.Bind<ITeamProjectService>().To<TeamProjectManager>();

            kernel.Bind<ITeamMemberRepository>().To<TeamMemberRepository>();

            kernel.Bind<IStatusRepository>().To<StatusRepository>();
            kernel.Bind<IDifficultyRepository>().To<DifficultyRepository>();

            kernel.Bind<ICommonService>().To<CommonManager>();

            kernel.Bind<IWorkItemRepository>().To<WorkItemRepository>();
            kernel.Bind<IWorkItemsEngine>().To<WorkItemsEngine>();
            kernel.Bind<IWorkItemsService>().To<WorkItemsManager>();

            kernel.Bind<IPriorityRepository>().To<PriorityRepository>();


            
        }        
    }
}
