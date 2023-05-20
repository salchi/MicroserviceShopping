using MediatR;
using System.Diagnostics;

namespace MicroserviceShopping.ProductService.Behaviors
{
   public class PerformanceLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
   {
      private readonly ILogger<PerformanceLoggingBehavior<TRequest, TResponse>> logger;

      public PerformanceLoggingBehavior(ILogger<PerformanceLoggingBehavior<TRequest, TResponse>> logger)
      {
         this.logger = logger;
      }

      public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
      {
         var sw = new Stopwatch();

         try
         {
            sw.Start();

            return await next();
         }
         catch (Exception)
         {
            throw;
         }
         finally
         {
            sw.Stop();

            logger.LogInformation("Execution of {@Request} took {ElapsedMs}ms.", request, sw.ElapsedMilliseconds);
         }
      }
   }
}
