using MicroserviceShopping.ProductService.Domain.Manufacturers;

namespace MicroserviceShopping.ProductService.Infrastructure.Repositories.Manufacturers
{
   internal class InMemoryManufacturerRepository : IManufacturerRepository
   {
      private static readonly List<Manufacturer> manufacturers = new();

      public Task<int> AddAsync(Manufacturer manufacturer, CancellationToken cancellationToken = default)
      {
         var newId = manufacturers.Select(m => m.Id).DefaultIfEmpty(0).Max() + 1;
         var added = new Manufacturer(newId, manufacturer.Name, manufacturer.Address);

         manufacturers.Add(added);

         return Task.FromResult(newId);
      }

      public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
      {
         var found = await GetByIdAsync(id, cancellationToken);
         if (found is not null)
            manufacturers.Remove(found);
      }

      public Task<Manufacturer?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
      {
         var found = manufacturers.FirstOrDefault(m => m.Id == id);
         return Task.FromResult(found);
      }

      public Task UpdateAsync(Manufacturer manufacturer, CancellationToken cancellationToken = default)
      {
         var idx = manufacturers.FindIndex(m => m.Id == manufacturer.Id);
         if (idx == -1) return Task.CompletedTask;

         manufacturers[idx] = manufacturer;

         return Task.CompletedTask;
      }
   }
}
