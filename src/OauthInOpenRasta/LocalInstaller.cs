using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using OpenRasta.OperationModel.Interceptors;

namespace OauthInOpenRasta
{
	public class LocalInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			var descriptor = AllTypes
				.FromAssembly(typeof(LocalInstaller).Assembly)
				.Pick()
				//.Unless(x => x.IsSubclassOf(typeof(OperationInterceptor)))
				.WithService.FirstInterface()
				.Configure(c => c.LifeStyle.Transient);

			container.Register(descriptor);
		}
	}
}