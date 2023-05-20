using FluentValidation;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Queries.Delete
{
   public class DeleteManufacturerByIdQueryValidator : AbstractValidator<DeleteManufacturerByIdCommand>
   {
      public DeleteManufacturerByIdQueryValidator()
      {
         RuleFor(query => query.Id).GreaterThan(0);
      }
   }
}
