using System;
using System.Collections;

namespace AopWithCastle
{
  public class BoxOfBeans : IEnumerable
  {
    private static readonly Random Random = new Random();
    private readonly object[] _internalArray;

    public BoxOfBeans()
    {
      _internalArray = new object[Random.Next(10, 100)];
    }

    public IEnumerator GetEnumerator()
    {
      return _internalArray.GetEnumerator();
    }
  }
}
