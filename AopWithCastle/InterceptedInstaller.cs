using Castle.Core;
using Castle.Core.Interceptor;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace AopWithCastle
{
  using System;
  using System.IO;

  // Installs BeanCounter as concrete type for IBeanCounter service with the
  // addition of an error handler interceptor to catch and handle any exceptions
  // thrown by the Count method (techically any method, but IBeanCounter only
  // has one method).
  public class InterceptedInstaller : IWindsorInstaller
  {
    private readonly TextWriter _logWriter;

    public InterceptedInstaller(TextWriter logWriter = null)
    {
      _logWriter = logWriter ?? Console.Out;
    }

    public void Install(IWindsorContainer container, IConfigurationStore store)
      => container.Register(
        Component.For<IInterceptor>()
          .ImplementedBy<ErrorHandlerInterceptor>()
          .Named("XInterceptor"),
        Component.For<IBeanCounter>()
          .ImplementedBy<BeanCounter>()
          .Interceptors(
            InterceptorReference.ForKey("XInterceptor")).Anywhere,
        Component.For<TextWriter>().Instance(_logWriter));
  }
}
