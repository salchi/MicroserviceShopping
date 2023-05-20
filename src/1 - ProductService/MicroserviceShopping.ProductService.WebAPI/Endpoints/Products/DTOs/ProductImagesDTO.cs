using MicroserviceShopping.ProductService.Domain.Products;

namespace MicroserviceShopping.ProductService.Endpoints.Products.DTOs
{
   public class ProductImagesDTO
   {
      public Uri? Small { get; set; }
      public Uri? Medium { get; set; }
      public Uri? Large { get; set; }

      public ProductImagesDTO(ProductImages productImages)
      {
         Small = productImages.Small;
         Medium = productImages.Medium;
         Large = productImages.Large;
      }

      public ProductImagesDTO()
      {
         // nothing to do
      }

      public ProductImages ToDomainObject() => new(Small, Medium, Large);
   }
}
