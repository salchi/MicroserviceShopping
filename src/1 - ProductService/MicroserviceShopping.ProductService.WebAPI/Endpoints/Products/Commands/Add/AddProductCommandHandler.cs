using MediatR;
using MicroserviceShopping.ProductService.Domain;
using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Commands.Add
{
   public class AddProductCommandHandler : IRequestHandler<AddProductCommand, AddProductCommandResult>
   {
      private readonly IUnitOfWork unitOfWork;
      private readonly ILogger<AddProductCommandHandler> logger;

      public AddProductCommandHandler(IUnitOfWork unitOfWork, ILogger<AddProductCommandHandler> logger)
      {
         this.unitOfWork = unitOfWork;
         this.logger = logger;
      }

      public async Task<AddProductCommandResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
      {
         var manufacturerExists = await unitOfWork.Manufacturers.ExistsAsync(request.Product.ManufacturerId, cancellationToken);
         if (!manufacturerExists)
         {
            logger.LogWarning("Product {@Product} can't be added, because manufacturer does not exist.", request.Product);
            return AddProductCommandResult.ForManufacturerDoesNotExist();
         }

         var toAdd = request.Product.ToDomainObject();
         var generatedId = await unitOfWork.Products.AddAsync(toAdd, cancellationToken);

         var dto = new ProductDTO(toAdd) { Id = generatedId };

         return AddProductCommandResult.ForSuccess(dto);
      }
   }
}
