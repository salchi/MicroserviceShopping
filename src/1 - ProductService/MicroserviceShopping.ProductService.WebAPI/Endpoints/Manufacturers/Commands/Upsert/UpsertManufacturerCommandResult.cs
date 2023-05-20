using MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Commands.Upsert
{
   public class UpsertManufacturerCommandResult
   {
      public ManufacturerDTO Manufacturer { get; }
      public bool WasAdded { get; }

      public UpsertManufacturerCommandResult(ManufacturerDTO manufacturer, bool wasAdded)
      {
         Manufacturer = manufacturer;
         WasAdded = wasAdded;
      }
   }
}
