using Ardalis.GuardClauses;

namespace MicroserviceShopping.ProductService.Domain.Manufacturers
{
   public class Address
   {
      public string Line1 { get; }
      public string? Line2 { get; }
      public bool HasSecondLine => !string.IsNullOrWhiteSpace(Line2);
      public City City { get; }

      public Address(string line1, string? line2, City city)
      {
         Line1 = Guard.Against.NullOrWhiteSpace(line1);
         Line2 = line2 ?? string.Empty;
         City = Guard.Against.Null(city);
      }
   }
}
