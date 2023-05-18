using Ardalis.GuardClauses;

namespace MicroserviceShopping.ProductService.Domain.Products
{
   public class ProductImages
   {
      public Uri Small { get; }
      public Uri Medium { get; }
      public Uri Large { get; }

      public ProductImages(Uri small, Uri medium, Uri large)
      {
         Small = Guard.Against.Null(small);
         Medium = Guard.Against.Null(medium);
         Large = Guard.Against.Null(large);
      }
   }
}
