using MicroserviceShopping.ProductService.Domain.Manufacturers;
using MicroserviceShopping.ProductService.Domain.Products;

namespace MicroserviceShopping.ProductService.Domain
{
   public interface IUnitOfWork
   {
      IProductRepository Products { get; }
      IManufacturerRepository Manufacturers { get; }

      Task CompleteAsync(CancellationToken cancellationToken = default);
   }
}
