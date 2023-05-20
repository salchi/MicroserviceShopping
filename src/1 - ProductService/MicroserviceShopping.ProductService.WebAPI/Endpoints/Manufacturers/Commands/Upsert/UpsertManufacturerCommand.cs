using MediatR;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Commands.Upsert
{
   public class UpsertManufacturerCommand : IRequest<UpsertManufacturerCommandResult>
   {
      public ManufacturerDTO Manufacturer { get; set; } = default!;
   }
}
