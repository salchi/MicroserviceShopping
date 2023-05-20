using MediatR;
using MicroserviceShopping.ProductService.Domain;
using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Queries.Search
{
   public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, SearchProductsQueryResult>
   {
      private readonly IUnitOfWork unitOfWork;

      public SearchProductsQueryHandler(IUnitOfWork unitOfWork)
      {
         this.unitOfWork = unitOfWork;
      }

      public async Task<SearchProductsQueryResult> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
      {
         var products = await unitOfWork.Products.SearchAsync(request.SearchTerm, cancellationToken);
         var dtos = products.Select(p => new ProductDTO(p)).ToList();

         return new SearchProductsQueryResult(dtos);
      }
   }
}
