using MicroserviceShopping.ProductService.Domain.Manufacturers;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs
{
   public class AddressDTO
   {
      public string Line1 { get; }
      public string? Line2 { get; }
      public CityDTO City { get; }

      public AddressDTO(Address address)
      {
         Line1 = address.Line1;
         Line2 = address.Line2;
         City = new CityDTO(address.City);
      }
   }
}
