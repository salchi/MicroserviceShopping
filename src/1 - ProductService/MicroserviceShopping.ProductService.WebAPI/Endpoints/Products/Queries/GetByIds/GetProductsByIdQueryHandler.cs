using MediatR;
using MicroserviceShopping.ProductService.Domain;
using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Queries.GetByIds
{
   public class GetProductsByIdQueryHandler : IRequestHandler<GetProductsByIdQuery, GetProductsByIdQueryResult>
   {
      private readonly IUnitOfWork unitOfWork;

      public GetProductsByIdQueryHandler(IUnitOfWork unitOfWork)
      {
         this.unitOfWork = unitOfWork;
      }

      public async Task<GetProductsByIdQueryResult> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
      {
         var products = await unitOfWork.Products.GetByIdsAsync(request.Ids, cancellationToken);
         var dtos = products.Select(p => new ProductDTO(p)).ToList();

         return new GetProductsByIdQueryResult(dtos);
      }
   }
}
