using Ardalis.GuardClauses;

namespace MicroserviceShopping.ProductService.Domain.Manufacturers
{
   public class City
   {
      public string CountryCode { get; }
      public string ZipCode { get; }
      public string Name { get; }

      public City(string countryCode, string zipCode, string name)
      {
         CountryCode = (countryCode is not null && countryCode.Length == 2) 
            ? countryCode 
            : throw new ArgumentException($"{nameof(countryCode)} must conform to ISO 3166-1 Alpha-2 codes.");
         ZipCode =  Guard.Against.NullOrWhiteSpace(zipCode);
         Name = Guard.Against.NullOrWhiteSpace(name);
      }
   }
}
