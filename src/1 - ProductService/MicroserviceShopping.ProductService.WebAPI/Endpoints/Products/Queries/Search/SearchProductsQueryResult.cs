using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Queries.Search
{
   public class SearchProductsQueryResult
   {
      public IReadOnlyCollection<ProductDTO> Products { get; }

      public SearchProductsQueryResult(IReadOnlyCollection<ProductDTO> products)
      {
         Products = products;
      }
   }
}
