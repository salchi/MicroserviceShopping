using MicroserviceShopping.ProductService.Domain.Manufacturers;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs
{
   public class CityDTO
   {
      public string CountryCode { get; set; } = string.Empty;
      public string ZipCode { get; set; } = string.Empty;
      public string Name { get; set; } = string.Empty;

      public CityDTO(City city)
      {
         CountryCode = city.CountryCode;
         ZipCode = city.ZipCode;
         Name = city.Name;
      }

      public CityDTO()
      {
         // nothing to do
      }

      public City ToCity() => new(CountryCode, ZipCode, Name);
   }
}
