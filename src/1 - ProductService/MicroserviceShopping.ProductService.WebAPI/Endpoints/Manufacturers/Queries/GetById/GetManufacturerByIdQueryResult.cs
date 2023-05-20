using MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Queries.GetById
{
   public class GetManufacturerByIdQueryResult
   {
      public ManufacturerDTO? Manufacturer { get; }
      public bool WasFound => Manufacturer is not null;

      public GetManufacturerByIdQueryResult(ManufacturerDTO? manufacturer)
      {
         Manufacturer = manufacturer;
      }
   }
}
