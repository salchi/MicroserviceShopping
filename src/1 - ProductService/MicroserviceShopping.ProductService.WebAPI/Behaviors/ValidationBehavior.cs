﻿using FluentValidation;
using MediatR;

namespace MicroserviceShopping.ProductService.Behaviors
{
   public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
   {
      private readonly IEnumerable<IValidator<TRequest>> validators;

      public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
         => this.validators = validators;

      public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
      {
         foreach (var validator in validators)
            await validator.ValidateAndThrowAsync(request, cancellationToken);

         return await next();
      }
   }
}