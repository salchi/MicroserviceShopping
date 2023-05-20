using MediatR;
using MicroserviceShopping.ProductService.Domain;
using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Queries.GetById
{
   public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
   {
      private readonly IUnitOfWork unitOfWork;

      public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
      {
         this.unitOfWork = unitOfWork;
      }

      public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
      {
         var product = await unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);
         var dto = product is not null ? new ProductDTO(product) : null;

         return new GetProductByIdQueryResult(dto);
      }
   }
}
