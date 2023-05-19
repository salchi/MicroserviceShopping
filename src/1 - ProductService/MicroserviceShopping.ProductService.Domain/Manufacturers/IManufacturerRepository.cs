namespace MicroserviceShopping.ProductService.Domain.Manufacturers
{
   public interface IManufacturerRepository
   {
      Task<int> AddAsync(Manufacturer manufacturer, CancellationToken cancellationToken = default);
      Task UpdateAsync(Manufacturer manufacturer, CancellationToken cancellationToken = default);
      Task DeleteAsync(Manufacturer manufacturer, CancellationToken cancellationToken = default);
      Task<Manufacturer?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
   }
}
