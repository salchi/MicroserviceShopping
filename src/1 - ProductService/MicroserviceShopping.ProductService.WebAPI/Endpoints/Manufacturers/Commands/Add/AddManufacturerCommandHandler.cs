using MediatR;
using MicroserviceShopping.ProductService.Domain;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Commands.Add
{
   public class AddManufacturerCommandHandler : IRequestHandler<AddManufacturerCommand, AddManufacturerCommandResult>
   {
      private readonly IUnitOfWork unitOfWork;

      public AddManufacturerCommandHandler(IUnitOfWork unitOfWork)
      {
         this.unitOfWork = unitOfWork;
      }

      public async Task<AddManufacturerCommandResult> Handle(AddManufacturerCommand request, CancellationToken cancellationToken)
      {
         var toAdd = request.Manufacturer.ToManufacturer();

         var id = await unitOfWork.Manufacturers.AddAsync(toAdd, cancellationToken);
         var addedDTO = new ManufacturerDTO(toAdd)
         {
            Id = id
         };

         return new AddManufacturerCommandResult(addedDTO);
      }
   }
}
