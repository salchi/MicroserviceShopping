using MediatR;
using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;
using MicroserviceShopping.ProductService.Endpoints.Products.Queries.GetByIds;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MicroserviceShopping.ProductService.Endpoints.Products
{
   [Route("api/v1/products")]
   [ApiController]
   public class ProductController : ControllerBase
   {
      private readonly IMediator mediator;

      public ProductController(IMediator mediator)
      {
         this.mediator = mediator;
      }

      [HttpGet]
      [Route("", Name = "GetProductsById")]
      [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(ProductDTO[]))]
      [SwaggerResponse((int)HttpStatusCode.BadRequest)]
      [SwaggerResponse((int)HttpStatusCode.NotFound)]
      public async Task<IActionResult> GetProductsByIdAsync([FromQuery] GetProductsByIdQuery query, CancellationToken cancellationToken)
      {
         var result = await mediator.Send(query, cancellationToken);

         if (result.Products.Any())
            return Ok(result.Products);

         return NotFound();
      }
   }
}
