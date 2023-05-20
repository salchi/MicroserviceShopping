using MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Commands.Add
{
   public class AddManufacturerCommandResult
   {
      public ManufacturerDTO Manufacturer { get; }

      public AddManufacturerCommandResult(ManufacturerDTO manufacturer)
      {
         Manufacturer = manufacturer;
      }
   }
}
