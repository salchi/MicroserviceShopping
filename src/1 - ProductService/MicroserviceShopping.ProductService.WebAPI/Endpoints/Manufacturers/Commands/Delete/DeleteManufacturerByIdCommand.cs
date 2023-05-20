using MediatR;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Queries.Delete
{
   public class DeleteManufacturerByIdCommand : IRequest<DeleteManufacturerByIdCommandResult>
   {
      public int Id { get; set; }
   }
}
