using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Queries.GetById
{
   public class GetProductByIdQueryResult
   {
      public ProductDTO? Product { get; }
      public bool WasFound => Product is not null;

      public GetProductByIdQueryResult(ProductDTO? product)
      {
         Product = product;
      }
   }
}
