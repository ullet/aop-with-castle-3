namespace AopWithCastle
{
  using Castle.MicroKernel.Registration;
  using Castle.MicroKernel.SubSystems.Configuration;
  using Castle.Windsor;

  // Simply installs BeanCounter as the concrete type for the service without
  // any decoration.
  public class UninterceptedInstaller : IWindsorInstaller
  {
    public void Install(IWindsorContainer container, IConfigurationStore store)
      => container.Register(
        Component.For<IBeanCounter>()
          .ImplementedBy<BeanCounter>());
  }
}
