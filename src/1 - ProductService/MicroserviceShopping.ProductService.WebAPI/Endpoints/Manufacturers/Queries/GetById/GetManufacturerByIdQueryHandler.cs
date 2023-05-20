using MediatR;
using MicroserviceShopping.ProductService.Domain;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Queries.GetById
{
   public class GetManufacturerByIdQueryHandler : IRequestHandler<GetManufacturerByIdQuery, GetManufacturerByIdQueryResult>
   {
      private readonly IUnitOfWork unitOfWork;

      public GetManufacturerByIdQueryHandler(IUnitOfWork unitOfWork)
      {
         this.unitOfWork = unitOfWork;
      }

      public async Task<GetManufacturerByIdQueryResult> Handle(GetManufacturerByIdQuery request, CancellationToken cancellationToken)
      {
         var manufacturer = await unitOfWork.Manufacturers.GetByIdAsync(request.Id, cancellationToken);
         var dto = manufacturer is not null ? new ManufacturerDTO(manufacturer) : null;

         return new GetManufacturerByIdQueryResult(dto);
      }
   }
}
