using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Queries.GetByIds
{
   public class GetProductsByIdQueryResult
   {
      public IReadOnlyCollection<ProductDTO> Products { get; }

      public GetProductsByIdQueryResult(IReadOnlyCollection<ProductDTO> products)
      {
         Products = products;
      }
   }
}
