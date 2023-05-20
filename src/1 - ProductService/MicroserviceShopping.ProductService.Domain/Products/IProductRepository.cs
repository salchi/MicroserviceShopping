namespace MicroserviceShopping.ProductService.Domain.Products
{
   public interface IProductRepository
   {
      Task<int> AddAsync(Product product, CancellationToken cancellationToken = default);
      Task UpdateAsync(Product product, CancellationToken cancellationToken = default);
      Task DeleteAsync(int id, CancellationToken cancellationToken = default);
      Task<IReadOnlyList<Product>> GetByIdsAsync(IReadOnlyCollection<int> ids, CancellationToken cancellationToken = default);
      Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
      // NOTE: in a real world app, paging would be necessary
      Task<IReadOnlyList<Product>> SearchAsync(string searchTerm, CancellationToken cancellationToken = default);
   }
}
