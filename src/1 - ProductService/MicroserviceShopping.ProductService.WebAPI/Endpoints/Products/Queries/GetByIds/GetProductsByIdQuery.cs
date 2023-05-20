using MediatR;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Queries.GetByIds
{
   public class GetProductsByIdQuery : IRequest<GetProductsByIdQueryResult>
   {
      public IReadOnlyCollection<int> Ids { get; set; } = new List<int>();
   }
}
