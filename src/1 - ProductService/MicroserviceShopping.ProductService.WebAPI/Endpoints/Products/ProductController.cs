using MediatR;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.Commands.Add;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.Commands.Upsert;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.DTOs;
using MicroserviceShopping.ProductService.Endpoints.Manufacturers.Queries.GetById;
using MicroserviceShopping.ProductService.Endpoints.Products.Commands.Add;
using MicroserviceShopping.ProductService.Endpoints.Products.Commands.Upsert;
using MicroserviceShopping.ProductService.Endpoints.Products.DTOs;
using MicroserviceShopping.ProductService.Endpoints.Products.Queries.GetById;
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
      [Route("{Id}", Name = "GetProductById")]
      [SwaggerResponse((int)HttpStatusCode.OK, type: typeof(ProductDTO))]
      [SwaggerResponse((int)HttpStatusCode.BadRequest)]
      [SwaggerResponse((int)HttpStatusCode.NotFound)]
      public async Task<IActionResult> GetProductByIdAsync([FromRoute] GetProductByIdQuery query, CancellationToken cancellationToken)
      {
         var result = await mediator.Send(query, cancellationToken);

         if (result.WasFound)
            return Ok(result.Product);

         return NotFound();
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

      [HttpPost]
      [Route("", Name = "AddProduct")]
      [SwaggerResponse((int)HttpStatusCode.Created, type: typeof(ProductDTO))]
      [SwaggerResponse((int)HttpStatusCode.BadRequest)]
      public async Task<IActionResult> AddProductAsync([FromBody] AddProductCommand command, CancellationToken cancellationToken)
      {
         var result = await mediator.Send(command, cancellationToken);
         if (!result.ManufacturerExists)
            return BadRequest();

         return GetCreatedResult(result.Product!);
      }

      [HttpPut]
      [Route("{Id}", Name = "UpsertProduct")]
      [SwaggerResponse((int)HttpStatusCode.Created, type: typeof(ProductDTO))]
      [SwaggerResponse((int)HttpStatusCode.NoContent)]
      [SwaggerResponse((int)HttpStatusCode.BadRequest)]
      public async Task<IActionResult> UpsertProductAsync([FromRoute] int Id, [FromBody] UpsertProductCommand command, CancellationToken cancellationToken)
      {
         command.Product.Id = Id;

         var result = await mediator.Send(command, cancellationToken);

         if (result.WasAdded)
            return GetCreatedResult(result.Product);

         return NoContent();
      }

      private CreatedResult GetCreatedResult(ProductDTO dto)
         => Created(Url.RouteUrl("GetProductById", new GetProductByIdQuery() { Id = dto.Id }) ?? string.Empty, dto);
   }
}
