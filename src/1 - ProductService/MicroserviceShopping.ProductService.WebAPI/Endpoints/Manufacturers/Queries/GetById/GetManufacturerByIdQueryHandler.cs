using MediatR;
using MicroserviceShopping.ProductService.Domain;

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
            return new GetManufacturerByIdQueryResult(manufacturer);
        }
    }
}
