using MediatR;
using MicroserviceShopping.ProductService.Domain;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Queries.Delete
{
   public class DeleteManufacturerByIdCommandHandler : IRequestHandler<DeleteManufacturerByIdCommand, DeleteManufacturerByIdCommandResult>
   {
      private readonly IUnitOfWork unitOfWork;

      public DeleteManufacturerByIdCommandHandler(IUnitOfWork unitOfWork)
      {
         this.unitOfWork = unitOfWork;
      }

      public async Task<DeleteManufacturerByIdCommandResult> Handle(DeleteManufacturerByIdCommand request, CancellationToken cancellationToken)
      {
         await unitOfWork.Manufacturers.DeleteAsync(request.Id, cancellationToken);
         return new DeleteManufacturerByIdCommandResult();
      }
   }
}
