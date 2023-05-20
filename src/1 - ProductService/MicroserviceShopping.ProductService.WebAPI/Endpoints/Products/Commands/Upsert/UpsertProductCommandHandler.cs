using MediatR;
using MicroserviceShopping.ProductService.Domain;
using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Commands.Upsert
{
   public class UpsertProductCommandHandler : IRequestHandler<UpsertProductCommand, UpsertProductCommandResult>
   {
      private readonly IUnitOfWork unitOfWork;

      public UpsertProductCommandHandler(IUnitOfWork unitOfWork)
      {
         this.unitOfWork = unitOfWork;
      }

      public async Task<UpsertProductCommandResult> Handle(UpsertProductCommand request, CancellationToken cancellationToken)
      {
         var toUpsert = request.Product.ToDomainObject();

         var resultDto = new ProductDTO(toUpsert);

         var persisted = await unitOfWork.Products.GetByIdAsync(toUpsert.Id, cancellationToken);
         var mustBeAdded = persisted is null;

         if (mustBeAdded)
            resultDto.Id = await unitOfWork.Products.AddAsync(toUpsert, cancellationToken);
         else
            await unitOfWork.Products.UpdateAsync(toUpsert, cancellationToken);

         return new UpsertProductCommandResult(resultDto, wasAdded: mustBeAdded);
      }
   }
}
