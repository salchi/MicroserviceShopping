using MediatR;

namespace MicroserviceShopping.ProductService.Endpoints.Products.Queries.GetById
{
   public class GetProductByIdQuery : IRequest<GetProductByIdQueryResult>
   {
      public int Id { get; set; }
   }
}
