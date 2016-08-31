namespace AopWithCastle
{
  using System;
  using System.IO;
  using Castle.DynamicProxy;

  public class ErrorHandlerInterceptor : IInterceptor
  {
    private readonly TextWriter _logger;

    public ErrorHandlerInterceptor(TextWriter logger)
    {
      _logger = logger;
    }

    public void Intercept(IInvocation invocation)
    {
      try
      {
        invocation.Proceed();
      }
      catch (Exception exception)
      {
        // Log the exception
        _logger.WriteLine(
          "* Error in method '{0}': {1}",
          invocation.Method.Name,
          exception.Message);

        // Set a default return value (in this case know it is int).
        // Could of course instead re-throw the exception.
        invocation.ReturnValue = 0;
      }
    }
  }
}
