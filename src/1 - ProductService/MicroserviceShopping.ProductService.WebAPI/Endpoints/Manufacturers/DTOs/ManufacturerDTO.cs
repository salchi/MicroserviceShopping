using MicroserviceShopping.ProductService.Domain.Manufacturers;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs
{
   public class ManufacturerDTO
   {
      public int Id { get; }
      public string Name { get; }
      public AddressDTO Address { get; }

      public ManufacturerDTO(Manufacturer manufacturer)
      {
         Id = manufacturer.Id;
         Name = manufacturer.Name;
         Address = new AddressDTO(manufacturer.Address);
      }
   }
}
