using MediatR;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Queries.GetById
{
    public class GetManufacturerByIdQuery : IRequest<GetManufacturerByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
