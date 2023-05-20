using FluentValidation;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Commands.Add
{
   public class AddManufacturerCommandValidator : AbstractValidator<AddManufacturerCommand>
   {
      public AddManufacturerCommandValidator()
      {
         RuleFor(cmd => cmd.Manufacturer).NotNull();
         RuleFor(cmd => cmd.Manufacturer.Name).NotEmpty();
         RuleFor(cmd => cmd.Manufacturer.Address).NotNull();
         RuleFor(cmd => cmd.Manufacturer.Address.Line1).NotEmpty();
         RuleFor(cmd => cmd.Manufacturer.Address.City).NotNull();
         RuleFor(cmd => cmd.Manufacturer.Address.City.Name).NotEmpty();
         RuleFor(cmd => cmd.Manufacturer.Address.City.CountryCode).Length(2);
         RuleFor(cmd => cmd.Manufacturer.Address.City.ZipCode).NotEmpty();
      }
   }
}
