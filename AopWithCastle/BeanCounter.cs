namespace AopWithCastle
{
  using System.Linq;

  public class BeanCounter : IBeanCounter
  {
    public int Count(BoxOfBeans beans) => beans.Cast<object>().Count();
  }
}
