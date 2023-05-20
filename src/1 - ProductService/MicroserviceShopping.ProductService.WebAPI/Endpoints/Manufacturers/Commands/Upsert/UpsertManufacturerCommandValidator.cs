using FluentValidation;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Commands.Upsert
{
   public class UpsertManufacturerCommandValidator : AbstractValidator<UpsertManufacturerCommand>
   {
      public UpsertManufacturerCommandValidator()
      {
         RuleFor(cmd => cmd.Manufacturer).NotNull();
         RuleFor(cmd => cmd.Manufacturer.Id).GreaterThanOrEqualTo(0);
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
