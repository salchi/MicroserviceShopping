namespace MicroserviceShopping.ProductService.Domain.Products
{
   public class ProductImages
   {
      public Uri? Small { get; }
      public Uri? Medium { get; }
      public Uri? Large { get; }

      public ProductImages(Uri? small, Uri? medium, Uri? large)
      {
         Small = small;
         Medium = medium;
         Large = large;
      }
   }
}
