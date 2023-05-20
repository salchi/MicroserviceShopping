using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Commands.Upsert
{
   public class UpsertProductCommandResult
   {
      public ProductDTO Product { get; }
      public bool WasAdded { get; }

      public UpsertProductCommandResult(ProductDTO product, bool wasAdded)
      {
         Product = product;
         WasAdded = wasAdded;
      }
   }
}
