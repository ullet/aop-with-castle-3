using System;
using System.Collections.Generic;
using Castle.Windsor;

namespace AopWithCastle
{
  public class Program
  {
    public static void Main(string[] args)
    {
      using (var container = new WindsorContainer())
      {
        container.Install(new AppInstaller());
        var beanCounter = container.Resolve<IBeanCounter>();
        CountSomeBeans(beanCounter);
      }
    }

    private static void CountSomeBeans(IBeanCounter beanCounter)
    {
      foreach (var boxOfBeans in BoxesOfBeans)
      {
        Console.Out.WriteLine(
          "There are {0} beans in the box.",
          beanCounter.Count(boxOfBeans));
      }
    }

    private static IEnumerable<BoxOfBeans> BoxesOfBeans
    {
      get
      {
        var boxesOfBeans = new[]
          {
            new BoxOfBeans(),
            new BoxOfBeans(),
            null,
            new BoxOfBeans(),
            new BoxOfBeans()
          };
        return boxesOfBeans;
      }
    }
  }
}
