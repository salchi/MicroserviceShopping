using Ardalis.GuardClauses;

namespace MicroserviceShopping.ProductService.Domain.Manufacturers
{
   public class Manufacturer
   {
      public int Id { get; }
      public string Name { get; }
      public Address Address { get; }

      public Manufacturer(int id, string name, Address address)
      {
         Id = Guard.Against.NegativeOrZero(id);
         Name = Guard.Against.NullOrWhiteSpace(name);
         Address = Guard.Against.Null(address);
      }
   }
}
