using MicroserviceShopping.ProductService.Domain.Manufacturers;

namespace MicroserviceShopping.ProductService.Infrastructure.Repositories.Manufacturers
{
   internal class InMemoryManufacturerRepository : IManufacturerRepository
   {
      public Task<int> AddAsync(Manufacturer manufacturer, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }

      public Task DeleteAsync(Manufacturer manufacturer, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }

      public Task<Manufacturer?> GetByIdAsync(IReadOnlyCollection<int> id, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }

      public Task UpdateAsync(Manufacturer manufacturer, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }
   }
}
