using FluentValidation;
using System.Net;

namespace MicroserviceShopping.ProductService.Middlewares
{
   public class ValidationExceptionMiddleware
   {
      private readonly RequestDelegate next;

      public ValidationExceptionMiddleware(RequestDelegate next) => this.next = next;

      public async Task InvokeAsync(HttpContext context)
      {
         try
         {
            await next(context);
         }
         catch (ValidationException)
         {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
         }
      }
   }
}
