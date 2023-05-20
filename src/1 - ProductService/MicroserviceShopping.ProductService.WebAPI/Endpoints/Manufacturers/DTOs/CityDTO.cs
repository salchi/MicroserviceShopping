using MicroserviceShopping.ProductService.Domain.Manufacturers;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs
{
   public class CityDTO
   {
      public string CountryCode { get; }
      public string ZipCode { get; }
      public string Name { get; }

      public CityDTO(City city)
      {
         CountryCode = city.CountryCode;
         ZipCode = city.ZipCode;
         Name = city.Name;
      }
   }
}
