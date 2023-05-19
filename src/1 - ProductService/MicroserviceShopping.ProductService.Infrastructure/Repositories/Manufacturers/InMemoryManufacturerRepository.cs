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

      public async Task<Manufacturer?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
      {
         await Task.CompletedTask;
         return new Manufacturer(id, "test", new Address("line1", null, new City("AT", "6060", "Hall")));
      }

      public Task UpdateAsync(Manufacturer manufacturer, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }
   }
}
