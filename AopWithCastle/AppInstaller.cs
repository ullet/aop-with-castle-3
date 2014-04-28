using Castle.Core;
using Castle.Core.Interceptor;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace AopWithCastle
{
  public class AppInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
      container.Register(
        Component.For<IInterceptor>()
                 .ImplementedBy<ErrorHandlerInterceptor>()
                 .Named("XInterceptor")
        );
      container.Register(
        Component.For<IBeanCounter>()
                 .ImplementedBy<BeanCounter>()
                 .Interceptors(
                   InterceptorReference.ForKey("XInterceptor")).Anywhere);
    }
  }
}
