using FluentValidation;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Queries.GetById
{
   public class GetManufacturerByIdQueryValidator : AbstractValidator<GetManufacturerByIdQuery>
   {
      public GetManufacturerByIdQueryValidator()
      {
         RuleFor(query => query.Id).GreaterThan(0);
      }
   }
}
