using MicroserviceShopping.ProductService.Domain.Products;

namespace MicroserviceShopping.ProductService.Infrastructure.Repositories.Products
{
   internal class InMemoryProductRepository : IProductRepository
   {
      public Task<int> AddAsync(Product product, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }

      public Task DeleteAsync(Product product, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }

      public Task<Product?> GetByIdAsync(IReadOnlyCollection<int> id, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }

      public Task<IReadOnlyList<Product>> GetByIdsAsync(IReadOnlyCollection<int> ids, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }

      public Task<IReadOnlyList<Product>> SearchAsync(string searchTerm, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }

      public Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }
   }
}
