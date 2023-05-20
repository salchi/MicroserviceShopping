using FluentValidation;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Commands.Add
{
   public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
   {
      public AddProductCommandValidator()
      {
         RuleFor(cmd => cmd.Product).NotNull();
         RuleFor(cmd => cmd.Product.Name).NotEmpty();
         RuleFor(cmd => cmd.Product.Description).NotEmpty();
         RuleFor(cmd => cmd.Product.Images).NotNull();
         RuleFor(cmd => cmd.Product.Images.Small).NotEmpty();
         RuleFor(cmd => cmd.Product.Images.Medium).NotEmpty();
         RuleFor(cmd => cmd.Product.Images.Large).NotEmpty();
         RuleFor(cmd => cmd.Product.ManufacturerId).GreaterThan(0);
      }
   }
}
