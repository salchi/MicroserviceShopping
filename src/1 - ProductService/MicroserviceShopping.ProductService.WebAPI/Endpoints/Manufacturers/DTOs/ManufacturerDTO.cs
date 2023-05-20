using MicroserviceShopping.ProductService.Domain.Manufacturers;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs
{
   public class ManufacturerDTO
   {
      public int Id { get; set; }
      public string Name { get; set; } = string.Empty;
      public AddressDTO Address { get; set; } = new AddressDTO();

      public ManufacturerDTO(Manufacturer manufacturer)
      {
         Id = manufacturer.Id;
         Name = manufacturer.Name;
         Address = new AddressDTO(manufacturer.Address);
      }

      public ManufacturerDTO()
      {
         // nothing to do
      }

      public Manufacturer ToDomainObject() => new(Id, Name, Address.ToDomainObject());
   }
}
