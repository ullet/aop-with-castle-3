namespace Tests
{
  using System;
  using System.Collections.Generic;
  using AopWithCastle;
  using Castle.Windsor;
  using NUnit.Framework;

  // Both intercepted and unintercepted BeanCounter can count good boxes of
  // beans but behaviour is different for a bad box. The Base class has test
  // cases for the common behaviour.
  public abstract class BeanCounterTestsBase
  {
    private static readonly Random RandomNumberGenerator = new Random();
    private IWindsorContainer _container;

    private IWindsorContainer Container
      => _container ?? (_container = new WindsorContainer().Install(Installer));

    protected IWindsorInstaller Installer { get; set; }

    protected IBeanCounter BeanCounter => Container.Resolve<IBeanCounter>();

    [SetUp]
    [TearDown]
    public void ResetContainer()
    {
      _container?.Dispose();
      _container = null;
    }

    [TestCaseSource(nameof(BoxesOfBeansTestCases))]
    public int CanCountGoodBoxesOfBeans(BoxOfBeans boxOfBeans)
      => BeanCounter.Count(boxOfBeans);

    // NB. A test case source must be protected if used in the abstract base
    // class, even if that test case source is only used in the base class.
    protected static IEnumerable<TestCaseData> BoxesOfBeansTestCases
      => new[]
      {
        BoxOfBeansTestCase(),
        BoxOfBeansTestCase(),
        BoxOfBeansTestCase(),
        BoxOfBeansTestCase(),
      };

    private static TestCaseData BoxOfBeansTestCase()
      => BoxOfBeansTestCase(RandomInt());

    private static TestCaseData BoxOfBeansTestCase(int count)
      => new TestCaseData(new BoxOfBeans(count)).Returns(count);

    private static int RandomInt() => RandomNumberGenerator.Next(10, 100);
  }
}
