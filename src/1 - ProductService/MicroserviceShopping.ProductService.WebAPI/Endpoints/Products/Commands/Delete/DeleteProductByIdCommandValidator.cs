using FluentValidation;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Commands.Delete
{
   public class DeleteProductByIdCommandValidator : AbstractValidator<DeleteProductByIdCommand>
   {
      public DeleteProductByIdCommandValidator()
      {
         RuleFor(cmd => cmd.Id).GreaterThan(0);
      }
   }
}
