using FluentValidation;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Queries.Search
{
   public class SearchProductsQueryValidator : AbstractValidator<SearchProductsQuery>
   {
      public SearchProductsQueryValidator()
      {
         RuleFor(query => query.SearchTerm).NotEmpty().MinimumLength(3);
      }
   }
}
