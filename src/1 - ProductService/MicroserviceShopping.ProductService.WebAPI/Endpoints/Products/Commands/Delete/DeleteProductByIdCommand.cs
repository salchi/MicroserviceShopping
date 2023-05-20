using MediatR;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Commands.Delete
{
   public class DeleteProductByIdCommand : IRequest<DeleteProductByIdCommandResult>
   {
      public int Id { get; set; }
   }
}
