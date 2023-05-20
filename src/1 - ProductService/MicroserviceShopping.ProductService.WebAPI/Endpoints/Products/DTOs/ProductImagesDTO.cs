using MicroserviceShopping.ProductService.Domain.Products;

namespace MicroserviceShopping.ProductService.Endpoints.Products.DTOs
{
   public class ProductImagesDTO
   {
      public Uri Small { get; set; } = new(string.Empty);
      public Uri Medium { get; set; } = new(string.Empty);
      public Uri Large { get; set; } = new(string.Empty);

      public ProductImagesDTO(ProductImages productImages)
      {
         Small = productImages.Small;
         Medium = productImages.Medium;
         Large = productImages.Large;
      }
   }
}
