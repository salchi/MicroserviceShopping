using Ardalis.GuardClauses;

namespace MicroserviceShopping.ProductService.Domain.Products
{
   public class Product
   {
      public int Id { get; }
      public string Name { get; }
      public string Description { get; }
      public ProductImages Images { get; }

      public int ManufacturerId { get; }

      public Product(int id, string name, string description, ProductImages images, int manufacturerId)
      {
         Id = Guard.Against.NegativeOrZero(id);
         Name = Guard.Against.NullOrWhiteSpace(name);
         Description = Guard.Against.NullOrWhiteSpace(description);
         Images = Guard.Against.Null(images);
         ManufacturerId = Guard.Against.NegativeOrZero(manufacturerId);
      }
   }
}
