using MediatR;
using MicroserviceShopping.ProductService.Domain;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Commands.Upsert
{
   public class UpsertManufacturerCommandHandler : IRequestHandler<UpsertManufacturerCommand, UpsertManufacturerCommandResult>
   {
      private readonly IUnitOfWork unitOfWork;

      public UpsertManufacturerCommandHandler(IUnitOfWork unitOfWork)
      {
         this.unitOfWork = unitOfWork;
      }

      public async Task<UpsertManufacturerCommandResult> Handle(UpsertManufacturerCommand request, CancellationToken cancellationToken)
      {
         var toUpsert = request.Manufacturer.ToDomainObject();

         var resultDto = new ManufacturerDTO(toUpsert);

         var persisted = await unitOfWork.Manufacturers.GetByIdAsync(toUpsert.Id, cancellationToken);
         var mustBeAdded = persisted is null;

         if (mustBeAdded)
            resultDto.Id = await unitOfWork.Manufacturers.AddAsync(toUpsert, cancellationToken);
         else
            await unitOfWork.Manufacturers.UpdateAsync(toUpsert, cancellationToken);

         return new UpsertManufacturerCommandResult(resultDto, wasAdded: mustBeAdded);
      }
   }
}
