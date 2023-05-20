using MediatR;
using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Commands.Add
{
   public class AddProductCommand : IRequest<AddProductCommandResult>
   {
      public ProductWithoutIdDTO Product { get; set; } = default!;
   }
}
