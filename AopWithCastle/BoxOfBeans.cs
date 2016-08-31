namespace AopWithCastle
{
  using System.Collections;

  public class BoxOfBeans : IEnumerable
  {
    private readonly object[] _internalArray;

    public BoxOfBeans(int numberOfBeans)
    {
      _internalArray = new object[numberOfBeans];
    }

    public IEnumerator GetEnumerator() => _internalArray.GetEnumerator();
  }
}
