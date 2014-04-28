using System;
using Castle.Core.Interceptor;

namespace AopWithCastle
{
  public class ErrorHandlerInterceptor : IInterceptor
  {
    public void Intercept(IInvocation invocation)
    {
      try
      {
        invocation.Proceed();
      }
      catch (Exception exception)
      {
        // Log the exception
        Console.Out.WriteLine(
          "* Error in method '{0}': {1}",
          invocation.Method.Name,
          exception.Message);

        // Set a default return value (in this case know it is int)
        invocation.ReturnValue = 0;
      }
    }
  }
}
