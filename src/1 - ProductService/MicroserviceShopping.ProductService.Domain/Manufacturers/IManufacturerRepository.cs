namespace MicroserviceShopping.ProductService.Domain.Manufacturers
{
   public interface IManufacturerRepository
   {
      Task<int> AddAsync(Manufacturer manufacturer, CancellationToken cancellationToken = default);
      Task UpdateAsync(Manufacturer manufacturer, CancellationToken cancellationToken = default);
      Task DeleteAsync(int id, CancellationToken cancellationToken = default);
      Task<Manufacturer?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
      Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default);
   }
}
