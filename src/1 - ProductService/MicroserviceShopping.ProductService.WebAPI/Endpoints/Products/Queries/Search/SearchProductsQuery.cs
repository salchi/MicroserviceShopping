using MediatR;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Queries.Search
{
   public class SearchProductsQuery : IRequest<SearchProductsQueryResult>
   {
      public string SearchTerm { get; set; } = string.Empty;
   }
}
