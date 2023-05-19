using MicroserviceShopping.ProductService.Domain;
using MicroserviceShopping.ProductService.Domain.Manufacturers;
using MicroserviceShopping.ProductService.Domain.Products;

namespace MicroserviceShopping.ProductService.Infrastructure.Repositories
{
   internal class UnitOfWork : IUnitOfWork
   {
      public IProductRepository Products { get; }

      public IManufacturerRepository Manufacturers { get; }

      public UnitOfWork(IProductRepository products, IManufacturerRepository manufacturers)
      {
         Products = products;
         Manufacturers = manufacturers;
      }

      public Task CompleteAsync(CancellationToken cancellationToken = default)
      {
         throw new NotImplementedException();
      }
   }
}
