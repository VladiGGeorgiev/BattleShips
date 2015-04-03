using Microsoft.Owin;

[assembly: OwinStartup(typeof(Battleships.WebServices.Startup))]

namespace Battleships.WebServices
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web.Http;

    using Battleships.Data;

    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.UseNinjectMiddleware(this.CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            this.RegisterMappings(kernel);

            return kernel;
        }

        private void RegisterMappings(IKernel kernel)
        {
			// TODO: Make interface for the ApplicationDbContext!
            kernel.Bind<DbContext>().To<ApplicationDbContext>();
            kernel.Bind<IBattleshipsData>().To<BattleshipsData>();
        }
    }
}
