namespace AopWithCastle.Tests
{
  using System;
  using NUnit.Framework;
  using AopWithCastle;

  [TestFixture]
  public class UninterceptedBeanCounterTests : BeanCounterTestsBase
  {
    [SetUp]
    public void SetUp()
    {
      Installer = new UninterceptedInstaller();
    }

    [Test]
    public void BadBoxOfBeansThrowsException()
      => Assert.Throws<ArgumentNullException>(() => BeanCounter.Count(null));
  }
}
