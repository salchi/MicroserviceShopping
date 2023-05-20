using MicroserviceShopping.ProductService.Domain.Manufacturers;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs
{
   public class ManufacturerWithoutIdDTO
   {
      public string Name { get; set; } = string.Empty;
      public AddressDTO Address { get; set; } = new AddressDTO();

      public ManufacturerWithoutIdDTO(string name, AddressDTO address)
      {
         Name = name;
         Address = address;
      }

      public ManufacturerWithoutIdDTO()
      {
         // nothing to do
      }

      public Manufacturer ToManufacturer() => new(id: 0, Name, Address.ToAddress());
   }
}
