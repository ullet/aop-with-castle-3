namespace AopWithCastle.Tests
{
  using System.IO;
  using System.Text;
  using NUnit.Framework;
  using AopWithCastle;

  [TestFixture]
  public class InterceptedBeanCounterTests : BeanCounterTestsBase
  {
    private TextWriter _logWriter;
    private StringBuilder _log;

    [SetUp]
    public void SetUp()
    {
      _log = new StringBuilder();
      _logWriter = new StringWriter(_log);
      Installer = new InterceptedInstaller(_logWriter);
    }

    [Test]
    public void BadBoxOfBeansIsInterceptedAndCounted()
      => Assert.That(BeanCounter.Count(null), Is.EqualTo(0));

    [Test]
    public void BadBoxOfBeansIsInterceptedAndLogged()
    {
      BeanCounter.Count(null);
      Assert.That(_log.ToString(), Does.Contain("Error in method"));
    }
  }
}
