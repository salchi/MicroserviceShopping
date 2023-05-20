using MediatR;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Commands.Add
{
   public class AddManufacturerCommand : IRequest<AddManufacturerCommandResult>
   {
      public ManufacturerWithoutIdDTO Manufacturer { get; set; } = default!;
   }
}
