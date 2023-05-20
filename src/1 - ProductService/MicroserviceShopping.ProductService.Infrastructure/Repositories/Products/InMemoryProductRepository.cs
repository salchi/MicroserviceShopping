using MicroserviceShopping.ProductService.Domain.Products;

namespace MicroserviceShopping.ProductService.Infrastructure.Repositories.Products
{
   internal class InMemoryProductRepository : IProductRepository
   {
      private static readonly List<Product> products = new();

      public Task<int> AddAsync(Product product, CancellationToken cancellationToken = default)
      {
         var newId = products.Select(m => m.Id).DefaultIfEmpty(0).Max() + 1;
         var added = new Product(newId, product.Name, product.Description, product.Images, product.ManufacturerId);

         products.Add(added);

         return Task.FromResult(newId);
      }

      public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
      {
         var found = await GetByIdAsync(id, cancellationToken);
         if (found is not null)
            products.Remove(found);
      }

      public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
      {
         var products = await GetByIdsAsync(new[] { id }, cancellationToken);
         return products.FirstOrDefault();
      }

      public Task<IReadOnlyList<Product>> GetByIdsAsync(IReadOnlyCollection<int> ids, CancellationToken cancellationToken = default)
      {
         var found = (IReadOnlyList<Product>)products.Where(p => ids.Contains(p.Id)).ToList();
         return Task.FromResult(found ?? new List<Product>());
      }

      public Task<IReadOnlyList<Product>> SearchAsync(string searchTerm, CancellationToken cancellationToken = default)
      {
         var found = (IReadOnlyList<Product>)products.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm)).ToList();
         return Task.FromResult(found ?? new List<Product>());
      }

      public Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
      {
         var idx = products.FindIndex(p => p.Id == product.Id);
         if (idx == -1) return Task.CompletedTask;

         products[idx] = product;

         return Task.CompletedTask;
      }
   }
}
