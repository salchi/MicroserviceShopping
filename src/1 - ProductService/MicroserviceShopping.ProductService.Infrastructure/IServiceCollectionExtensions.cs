using MicroserviceShopping.ProductService.Domain;
using MicroserviceShopping.ProductService.Domain.Manufacturers;
using MicroserviceShopping.ProductService.Domain.Products;
using MicroserviceShopping.ProductService.Infrastructure.Repositories;
using MicroserviceShopping.ProductService.Infrastructure.Repositories.Manufacturers;
using MicroserviceShopping.ProductService.Infrastructure.Repositories.Products;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroserviceShopping.ProductService.Infrastructure
{
   public static class IServiceCollectionExtensions
   {
      public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
      {
         services.AddScoped<IManufacturerRepository, InMemoryManufacturerRepository>();
         services.AddScoped<IProductRepository, InMemoryProductRepository>();
         services.AddScoped<IUnitOfWork, UnitOfWork>();

         return services;
      }
   }
}
