using MicroserviceShopping.ProductService.Domain.Manufacturers;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs
{
   public class AddressDTO
   {
      public string Line1 { get; set; } = string.Empty;
      public string? Line2 { get; set; }
      public CityDTO City { get; set; } = new CityDTO();

      public AddressDTO(Address address)
      {
         Line1 = address.Line1;
         Line2 = address.Line2;
         City = new CityDTO(address.City);
      }

      public AddressDTO()
      {
         // nothing to do
      }

      public Address ToAddress() => new(Line1, Line2, City.ToCity());
   }
}
