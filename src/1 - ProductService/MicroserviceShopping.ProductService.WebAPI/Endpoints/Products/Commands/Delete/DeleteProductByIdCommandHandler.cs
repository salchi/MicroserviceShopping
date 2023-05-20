using MediatR;
using MicroserviceShopping.ProductService.Domain;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Commands.Delete
{
   public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, DeleteProductByIdCommandResult>
   {
      private readonly IUnitOfWork unitOfWork;

      public DeleteProductByIdCommandHandler(IUnitOfWork unitOfWork)
      {
         this.unitOfWork = unitOfWork;
      }

      public async Task<DeleteProductByIdCommandResult> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
      {
         await unitOfWork.Products.DeleteAsync(request.Id, cancellationToken);
         return new DeleteProductByIdCommandResult();
      }
   }
}
