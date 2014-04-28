namespace AopWithCastle
{
  public class BeanCounter : IBeanCounter
  {
    public int Count(BoxOfBeans beans)
    {
      int count = 0;
      var enumerator = beans.GetEnumerator();
      while (enumerator.MoveNext())
      {
        count++;
      }
      return count;
    }
  }
}
