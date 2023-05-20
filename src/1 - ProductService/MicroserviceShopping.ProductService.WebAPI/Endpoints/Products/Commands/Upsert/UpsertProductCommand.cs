using MediatR;
using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Commands.Upsert
{
   public class UpsertProductCommand : IRequest<UpsertProductCommandResult>
   {
      public ProductDTO Product { get; set; } = default!;
   }
}
