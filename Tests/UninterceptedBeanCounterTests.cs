namespace Tests
{
  using System;
  using AopWithCastle;
  using NUnit.Framework;

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
