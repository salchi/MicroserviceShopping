using MicroserviceShopping.ProductService.Domain.Manufacturers;

namespace MicroserviceShopping.ProductService.Endpoints.Manufacturers.Queries.GetById
{
    public class GetManufacturerByIdQueryResult
    {
        public Manufacturer? Manufacturer { get; }

        public GetManufacturerByIdQueryResult(Manufacturer? manufacturer)
        {
            Manufacturer = manufacturer;
        }
    }
}
