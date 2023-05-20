using FluentValidation;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Queries.GetByIds
{
   public class GetProductsByIdQueryValidator : AbstractValidator<GetProductsByIdQuery>
   {
        public GetProductsByIdQueryValidator()
        {
            RuleFor(query => query.Ids).NotNull().NotEmpty();
        }
    }
}
