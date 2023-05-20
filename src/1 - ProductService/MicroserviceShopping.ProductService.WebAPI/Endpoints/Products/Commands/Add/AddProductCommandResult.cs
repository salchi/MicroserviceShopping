using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Commands.Add
{
   public class AddProductCommandResult
   {
      public ProductDTO? Product { get; }
      public bool ManufacturerExists { get; }

      private AddProductCommandResult(ProductDTO? product, bool manufacturerExists)
      {
         Product = product;
         ManufacturerExists = manufacturerExists;
      }

      public static AddProductCommandResult ForSuccess(ProductDTO product) => new(product, manufacturerExists: true);
      public static AddProductCommandResult ForManufacturerDoesNotExist() => new(product: null, manufacturerExists: false);
   }
}
